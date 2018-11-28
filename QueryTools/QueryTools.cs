using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Utilities;

namespace QueryTools
{
    public static class queryTools
    {
        // https://stackoverflow.com/questions/21739242/filestream-and-a-filesystemwatcher-in-c-weird-issue-process-cannot-access-the
        public static bool IsFileClosed(string filepath, bool wait)
        {
            bool fileClosed = false;
            int retries = 20;
            const int delay = 500; // Max time spent here = retries*delay milliseconds

            if (!File.Exists(filepath))
                return false;

            do
            {
                try
                {
                    // Attempts to open then close the file in RW mode, denying other users to place any locks.
                    FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    fs.Close();
                    fileClosed = true; // success
                }
                catch (IOException) { }

                if (!wait) break;

                retries--;

                if (!fileClosed)
                    Thread.Sleep(delay);
            }
            while (!fileClosed && retries > 0);

            return fileClosed;
        }

        public static string servicesLocation = @"C:/Users/daniele/Documents/Visual Studio 2017/Projects/PacsParserNovembre/Services/";

        public static bool verbose = true;

        public static void doQuery(query queryData,string dir)
        {

            string query = "";
            foreach (string dicomTag in queryData.getKeys())
                query = " -k " + dicomTag + "=\"" + queryData.getValueByTag(dicomTag) + "\" " + query;


            string fullQuery =
                 " -S  -aec MIOSERVER " + query + " localhost 11112  -od " + dir + " --extract-xml ";


            DirectoryInfo di = Directory.CreateDirectory(dir);
            foreach (FileInfo file in di.GetFiles())
                file.Delete();

           // MessageBox.Show(fullQuery);

            initProcess("findscu", fullQuery);

        }


        public static void downloadSeries(seriesLevelQuery queryResults)
        {
            string query = "";
            foreach (string dicomTag in queryResults.getKeys())
                query = " -k " + dicomTag + "=\"" + queryResults.getValueByTag(dicomTag) + "\" " + query;

            string fullQuery =
                 " -aem USER  -aec MIOSERVER " + query + " localhost 11112";

            // launch query
            initProcess("movescu-dcmtk", fullQuery);
        }

        /*  public static void downloadStudy(studyLevelQuery studyInputs)
          {
              string query = "";
              query = " -k QueryRetrieveLevel=\"STUDY\" " + query;
              query = " -k StudyInstanceUID=\"" + studyInputs.StudyInstanceUID + "\"" + query;
              query = " -k PatientID=\"" + studyInputs.PatientID + "\"" + query;

              string fullQuery =
                   " -aem USER  -aec MIOSERVER " + query + " localhost 11112";

              // launch query
              initProcess("movescu-dcmtk", fullQuery);
          } */


        public static void initProcess(string queryType, string arguments)
        {
            arguments = arguments + " -v";

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = servicesLocation + queryType,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (verbose) Console.WriteLine(line);
            }
        }
    }
}

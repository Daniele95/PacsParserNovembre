using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace QueryTools
{
    public static class queryTools
    {
        public static string servicesLocation = @"C:/Users/daniele/Documents/Visual Studio 2017/Projects/PacsParserNovembre/Services/";

        public static string databaseLocation = @"C:/Users/daniele/Desktop/DATABASE";



        public static void doStudyLevelQuery(studyLevelQuery queryData)
        {

            string query = "";
            foreach (string dicomTag in queryData.getKeys())
                query = " -k " + dicomTag + "=\"" + queryData.getElementByTag(dicomTag) + "\" " + query;


            string fullQuery =
                 " -S  -aec MIOSERVER " + query + " localhost 11112  -od " + databaseLocation + " -v --extract-xml ";


            DirectoryInfo di = Directory.CreateDirectory(databaseLocation);
            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            initProcess("findscu", fullQuery);

        }
        public static void initProcess(string queryType, string arguments)
        {
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
                Console.WriteLine(line);
            }
        }
    }
}

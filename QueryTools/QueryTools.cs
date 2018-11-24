using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryTools
{
    public static class queryTools
    {
        public static string servicesLocation = @"C:/Users/daniele/Documents/Visual Studio 2017/Projects/PacsParserNovembre/Services/";

        public static string databaseLocation = @"C:/Users/daniele/Desktop/DATABASE";


        public static void launchQuery()
        {
            // query optionts
            string query = "";
            query = " -k PatientName=\"\" " + query;
            query = " -k PatientID " + query;
            query = " -k QueryRetrieveLevel=\"PATIENT\" " + query;
            string fullQuery =
                 " -P  -aec MIOSERVER " + query + " localhost 11112  -od "+ databaseLocation+" -v --extract-xml ";

            // launch query
            initProcess("findscu", fullQuery);
        }

        public static void findStudiesByPatientID(string patientID)
        {
            // query optionts
            string query = "";
            query = " -k PatientID=\"" + patientID + "\"" + query;
            query = " -k QueryRetrieveLevel=\"STUDY\" " + query;
            query = " -k StudyInstanceUID" + query;
            query = " -k StudyDate" + query;

            string fullQuery =
                 " -P  -aec MIOSERVER " + query + " localhost 11112  -od ./Results -v --extract-xml";

            // launch query
            initProcess("findscu", fullQuery);

        }

        public static void downloadStudy(string studyInstanceUID, string patientID)
        {
            string query = "";
            query = " -k QueryRetrieveLevel=\"STUDY\" " + query;
            query = " -k StudyInstanceUID=\"" + studyInstanceUID + "\"" + query;
            query = " -k PatientID=\"" + patientID + "\"" + query;

            string fullQuery =
                 " -aem USER  -aec MIOSERVER " + query + " localhost 11112 -v";

            // launch query
            initProcess("movescu-dcmtk", fullQuery);
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

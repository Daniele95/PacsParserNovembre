using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Utilities;
using QueryTools;

namespace DataHandlerTools
{
    public static class ReadFile
    {


        public static void dicom2xml(string path)
        {
            string arguments = " " + path + " " + path + ".xml";
            // queryTools.initProcess("dcm2xml", arguments);
        }

        public static downloadedFileInfo readDownloadedXml(string path)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            downloadedFileInfo downloadedFile = new downloadedFileInfo();
            downloadedFile.PatientName = findTag(doc, "PatientName");
            downloadedFile.StudyDescription = findTag(doc, "StudyDescription");
            downloadedFile.SeriesDescription = findTag(doc, "SeriesDescription");
            return downloadedFile;

        }


        public static query getXml(XmlDocument doc)
        {
            query queryResults;

            string level = findTag(doc, "QueryRetrieveLevel");

            if (level == "STUDY")
                queryResults = new studyLevelQuery();
            else if (level == "SERIES")
                queryResults = new seriesLevelQuery();
            else {
                MessageBox.Show("error: could not read query from xml file");
                queryResults = null;
            }

            List<string> queryKeys = queryResults.getKeys();

            foreach (string dicomTagName in queryKeys)
            {
                string result = findTag(doc, dicomTagName);
                queryResults.setValueOfTag(dicomTagName, result);
            }

            return queryResults;
        }

        static string findTag(XmlDocument doc, string dicomTagName)
        {

            XmlNodeList xnList;
            xnList = doc.SelectNodes("/data-set/element[@name='" + dicomTagName + "']");
            string result = "";
            if (xnList.Count > 0)
                result = xnList[0].InnerText;
            return result;
        }


        /*  static void readDicomDir()
        {
            string dir = @"C:\Users\daniele\Desktop\dicomDatabase";
            System.IO.StreamReader file = new System.IO.StreamReader(dir);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                line = Regex.Replace(line, @"[^\u0020-\u007F]", " ");


                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                line = regex.Replace(line, " ");
                line = line.Replace(" U", System.Environment.NewLine + " U");


                Console.WriteLine(line);
                string[] parts = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        */

    }
}

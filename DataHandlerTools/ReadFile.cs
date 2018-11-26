using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Utilities;

namespace DataHandlerTools
{
    public static class ReadFile
    {
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
                queryResults = new studyLevelQuery();
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Utilities;

namespace DataHandlerTools
{
    public static class ReadFile
    {
        public static studyLevelQuery getXml(XmlDocument doc)
        {
            XmlNodeList xnList;
            studyLevelQuery queryResults = new studyLevelQuery();

            List<string> queryKeys = queryResults.getKeys();
            foreach (string dicomTagName in queryKeys)
            {
                xnList = doc.SelectNodes("/data-set/element[@name='" + dicomTagName + "']");
                string result = "";
                if (xnList.Count > 0)
                    result = xnList[0].InnerText;
                queryResults.setValueOfTag(dicomTagName, result);
            }

            return queryResults;
        }

    }
}

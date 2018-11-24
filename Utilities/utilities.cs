using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class studyLevelQuery
    {
        
        Dictionary<string, string> queryData = new Dictionary<string, string>();

        public string QueryRetrieveLevel { get; set; } = "STUDY";
        public string PatientName { get; set; } = "";
        public string PatientBirthDate { get; set; } = "";
        public string PatientID { get; set; } = "";
        public string Modality { get; set; } = "";
        public string StudyInstanceUID { get; set; } = "";
        public string StudyDate { get; set; } = "";
        public string AccessionNumber { get; set; } = "";
        public string StudyDescription { get; set; } = "";

        public studyLevelQuery ()
        {
            init();
        }

        void init()
        {
            PropertyInfo[] properties = typeof(studyLevelQuery).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                queryData.Add(property.Name, property.GetValue(this).ToString());
            }
        }

        public void fill()
        {
            PropertyInfo[] properties =  typeof(studyLevelQuery).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                queryData[property.Name] = property.GetValue(this).ToString();
            }
        }

        public List<string> getKeys()
        {
            return new List<string>( queryData.Keys);
        }

        public string getValueByTag(string tag)
        {
            return queryData[tag];
        }

        public void setValueOfTag(string tag, string value)
        {
            PropertyInfo prop = this.GetType().GetProperty(tag, BindingFlags.Public |  BindingFlags.Instance);

            if (null != prop && prop.CanWrite) 
                prop.SetValue(this, value, null); 

            queryData[tag] = value;
        }

    }

    public abstract class Publisher
    {
        public delegate void EventHandler(studyLevelQuery s);
        public event EventHandler Event;

        public void RaiseEvent(studyLevelQuery s)
        {
            Event(s);
        }
    }

}

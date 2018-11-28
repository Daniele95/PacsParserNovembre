using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Utilities
{



    public abstract class fileCreatorAndListener : SinglePublisher
    {


        public string databaseLocation = "";
        public FileSystemWatcher watcher = new FileSystemWatcher();

        public fileCreatorAndListener(string dir)
        {
            listen(dir);
        }

        public void listen (string path)
        {
            databaseLocation = path;
            // create a listener for incoming results
            System.IO.DirectoryInfo di = Directory.CreateDirectory(path);
            watcher.Path = path;
            watcher.Created += new FileSystemEventHandler(onCreated);
            watcher.EnableRaisingEvents = true;
        }

        public abstract void onCreated(object o, FileSystemEventArgs e);
    }

    public class studyLevelQuery: query
    {
        public string QueryRetrieveLevel { get; set; } = "STUDY";
        public string PatientName { get; set; } = "";
        public string PatientBirthDate { get; set; } = "";
        public string PatientID { get; set; } = "";
        public string Modality { get; set; } = "";
        public string StudyInstanceUID { get; set; } = "";
        public string StudyDate { get; set; } = "";
        public string AccessionNumber { get; set; } = "";
        public string StudyDescription { get; set; } = "";
    }


    public class seriesLevelQuery : query
    {
        public string QueryRetrieveLevel { get; set; } = "SERIES";
        public string StudyInstanceUID { get; set; } = "";
        public string SeriesInstanceUID { get; set; } = "";
        public string SeriesDescription { get; set; } = "";
        public string PatientID { get; set; } = "";


        public seriesLevelQuery() : base()
        { }

        public seriesLevelQuery(studyLevelQuery studyQuery) : base()
        {
            setValueOfTag("StudyInstanceUID",studyQuery.getValueByTag("StudyInstanceUID"));
            setValueOfTag("PatientID", studyQuery.getValueByTag("PatientID"));
        }

    }

    public abstract class query
    {
        
        Dictionary<string, string> queryData = new Dictionary<string, string>();

        public query ()
        {
            init();
        }

        void init()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                queryData.Add(property.Name, property.GetValue(this).ToString());
            }
        }

        public void fill()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
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
   
    public abstract class SinglePublisher
    {
        public delegate void EventHandler(query s);
        public event EventHandler Event;

        public void RaiseEvent(query s)
        {
            Event(s);
        }


        public delegate void downloadArrivedHandler(string s);
        public event downloadArrivedHandler downloadArrivedEvent;

        public void raiseDownloadArrived(string s)
        {
            downloadArrivedEvent(s);
        }


    }

    public abstract class Publisher
    {
        public delegate void studyArrivedHandler(studyLevelQuery s);
        public event studyArrivedHandler studyArrived;

        public void raiseStudyArrived(studyLevelQuery s)
        {
            studyArrived(s);
        }

        public delegate void seriesArrivedHandler(seriesLevelQuery s);
        public event seriesArrivedHandler seriesArrived;

        public void raiseSeriesArrived(seriesLevelQuery s)
        {
            seriesArrived(s);
        }



        public delegate void downloadArrivedHandler(string s);
        public event downloadArrivedHandler downloadArrivedEvent;

        public void raiseDownloadArrived(string s)
        {
            downloadArrivedEvent(s);
        }

    }
}

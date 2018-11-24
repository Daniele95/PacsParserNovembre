using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using System.Windows.Threading;

namespace DataHandlerTools
{
    public abstract class Publisher
    {
        public delegate void EventHandler(string s);
        public event EventHandler Event;

        public void RaiseEvent(string s)
        {
            Event(s);
        }

    }

    public class incomingFileHandler : Publisher
    {
        public static string databaseLocation = @"C:/Users/daniele/Desktop/DATABASE";

        public FileSystemWatcher watcher = new FileSystemWatcher();

        public string dati = "";

        public WaitForChangedResult result;


        public incomingFileHandler()
        {
            // create a listener for incoming results
            watcher.Path = databaseLocation;
            watcher.Created += new FileSystemEventHandler(onCreated);
            watcher.EnableRaisingEvents = true;
        }

        void onCreated(object a, FileSystemEventArgs s)
        {
            RaiseEvent(s.ToString());
        }

        public void returnResults()
        {
            // leggi dati!!!
        }

    }

}

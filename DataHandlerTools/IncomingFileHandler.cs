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
using Utilities;

namespace DataHandlerTools
{

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
            RaiseEvent("ciao");
        }

        public void returnResults()
        {
            // leggi dati!!!
        }

    }

}

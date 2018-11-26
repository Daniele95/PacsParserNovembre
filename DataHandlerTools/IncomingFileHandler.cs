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
using System.Windows;

namespace DataHandlerTools
{

    public class incomingFileHandler : SinglePublisher
    {
        public static string databaseLocation="";

        public FileSystemWatcher watcher = new FileSystemWatcher();

        public string dati = "";

        public WaitForChangedResult result;


        public incomingFileHandler(string dir)
        {
            databaseLocation = dir;
            // create a listener for incoming results
            DirectoryInfo di = Directory.CreateDirectory(databaseLocation);
            watcher.Path = databaseLocation;
            watcher.Created += new FileSystemEventHandler(onCreated);
            watcher.EnableRaisingEvents = true;
        }

        void onCreated(object a, FileSystemEventArgs s)
        {
            XmlDocument doc = new XmlDocument();
            // RISOLVERE PROBLEMA:
            Thread.Sleep(2);

            try
            {
                doc.Load(s.FullPath);
                studyLevelQuery queryResults = ReadFile.getXml(doc);
                RaiseEvent(queryResults); // empty message
            }
            catch (FileNotFoundException) { MessageBox.Show(s.FullPath + " file not found"); }
            catch (IOException e) { MessageBox.Show(e.Message); }

        }


    }

}

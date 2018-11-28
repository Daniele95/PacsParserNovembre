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

    public class incomingFileHandler : fileCreatorAndListener
    {
        public string dati = "";

        public WaitForChangedResult result;

        public incomingFileHandler(string path) : base(path)
        {
        }

        public override void onCreated(object a, FileSystemEventArgs s)
        {
            string[] directory = databaseLocation.Split('/');
            if (directory[directory.Length - 1].Equals("Listener"))
            {
                // handle downloaded file
                string fullPath = s.FullPath.Substring(0, s.FullPath.Length - 5);
                raiseDownloadArrived(fullPath);
            }
            // parse xmls containing query info 
            else
            { 

                XmlDocument doc = new XmlDocument();
                // RISOLVERE PROBLEMA:
                Thread.Sleep(2);
                try
                {
                    doc.Load(s.FullPath);
                    query queryResults = ReadFile.getXml(doc);
                    RaiseEvent(queryResults); // empty message
                }
                catch (FileNotFoundException) { MessageBox.Show(s.FullPath + " file not found"); }
                catch (IOException e) { MessageBox.Show(e.Message); }
            }
        }
    }


}


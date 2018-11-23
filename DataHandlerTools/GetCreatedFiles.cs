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

    public class GetCreatedFiles
    {
        public FileSystemWatcher watcher = new FileSystemWatcher();

        public GetCreatedFiles ()
        {
            initWatcher();
            WaitForChangedResult result = watcher.WaitForChanged(WatcherChangeTypes.Created, 20000);
            // wait...
            Console.WriteLine(result.TimedOut);
        }

        public void initWatcher()
        {

            // create a listener for incoming results
            watcher.Path = @"C:/Users/daniele/Desktop/DATABASE";
            watcher.Created += new FileSystemEventHandler(onCreated);
            watcher.EnableRaisingEvents = true;
        }
        
        void onCreated(object a, FileSystemEventArgs s)
        {
            Console.WriteLine("ciao");
        }

    }
    
}

using DataHandlerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Utilities;

namespace DataHandlerManager
{
    public class dataHandlerManager : SinglePublisher
    {
        
        public incomingFileHandler incomingFileHandler;

        public dataHandlerManager(string dir)
        {   
            incomingFileHandler = new incomingFileHandler(dir); // init watcher
            incomingFileHandler.Event += onCreated;
            incomingFileHandler.downloadArrivedEvent += onDownloaded;
        }

        public void onCreated(query queryResults)
        {
            RaiseEvent(queryResults);
        }

        public void onDownloaded(string fullPath)
        {
            raiseDownloadArrived(fullPath);
        }



    }
}

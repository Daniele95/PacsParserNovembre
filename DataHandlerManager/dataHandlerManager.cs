using DataHandlerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Utilities;

namespace DataHandlerManager
{
    public class dataHandlerManager : SinglePublisher
    {
        
        incomingFileHandler incomingFileHandler;

        public dataHandlerManager(string dir)
        {   
            incomingFileHandler = new incomingFileHandler(dir); // init watcher
            incomingFileHandler.Event += onCreated;
        }

        public void onCreated(query queryResults)
        {
            RaiseEvent(queryResults);
        }

    }
}

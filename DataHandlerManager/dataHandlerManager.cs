using DataHandlerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DataHandlerManager
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
    public class dataHandlerManager : Publisher
    {

        int retrieveData = 0;

        incomingFileHandler incomingFileHandler;

        public dataHandlerManager()
        {   
            incomingFileHandler = new incomingFileHandler(); // init watcher
            incomingFileHandler.Event += onCreated;
        }

        public void onCreated(string a)
        {
            RaiseEvent(a);
        }


    }
}

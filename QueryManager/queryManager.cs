using System;
using System.Threading;
using DataHandlerManager;
using QueryTools;

namespace QueryManager
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
    public class queryManager : Publisher
    {
        public queryManager()
        {
            dataHandlerManager acceptor = new dataHandlerManager();
            acceptor.Event += onCreated;
            queryTools.launchQuery();
        }


        public void onCreated(string a)
        {
            Console.WriteLine("risultati arrivati!!");
            RaiseEvent(a);
        }


    }
}

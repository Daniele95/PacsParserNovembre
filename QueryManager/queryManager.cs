using System;
using System.Threading;
using DataHandlerManager;
using QueryTools;
using Utilities;

namespace QueryManager
{
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

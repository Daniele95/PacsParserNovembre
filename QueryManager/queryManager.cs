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
        }

        public void onButtonPressed()
        {
            queryTools.launchQuery();
        }

        public void onCreated(string a)
        {
            RaiseEvent(a);
        }

    }
}

using System;
using System.Threading;
using DataHandlerManager;
using DataHandlerTools;
using QueryTools;

namespace QueryManager
{
    public class Query
    {
        public Query()
        {
            dataHandlerManager acceptor = new dataHandlerManager();
            queryTools.launchQuery();
            // then you have to wait til acceptor is full
            Thread.Sleep(1000);
            acceptor.returnResults();
        }
    }
}

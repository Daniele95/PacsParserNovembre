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

        public void onButtonPressed(studyLevelQuery queryInputs)
        {
            queryTools.doStudyLevelQuery(queryInputs);
        }

        public void onCreated(studyLevelQuery queryResults)
        {
            RaiseEvent(queryResults);
        }

    }
}

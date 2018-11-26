using System;
using System.Threading;
using DataHandlerManager;
using QueryTools;
using Utilities;

namespace QueryManager
{
    
    public class queryManager : Publisher
    {
        string dir;
        public queryManager(string dir)
        {
            this.dir = dir;
            dataHandlerManager acceptor = new dataHandlerManager(dir);
            acceptor.Event += onCreated;
        }

        public void onButtonPressed(studyLevelQuery queryInputs)
        {
            queryTools.doQuery(queryInputs,dir);
        }

        public void onStudyButtonPressed(seriesLevelQuery queryInputs)
        {
            queryTools.doQuery(queryInputs,dir);
        }


        public void onCreated(query queryResults)
        {
            if(queryResults.GetType().Equals("studyLevelQuery"))
                raiseStudyArrived((studyLevelQuery)queryResults);

            if (queryResults.GetType().Equals("seriesLevelQuery"))
                raiseSeriesArrived((seriesLevelQuery)queryResults);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using DataHandlerManager;
using QueryTools;
using Utilities;

namespace QueryManager
{
    
    public class queryManager : Publisher
    {
        string dir;

        List<studyLevelQuery> studyLevelQueries = new List<studyLevelQuery>();
        List<seriesLevelQuery> seriesLevelQueries = new List<seriesLevelQuery>();

        seriesLevelQuery downloadedFileInfo;

        public queryManager(string dir)
        {
            this.dir = dir;
            dataHandlerManager  acceptor = new dataHandlerManager(dir);
            acceptor.Event += onCreated;
            acceptor.downloadArrivedEvent += onDownloaded;
        }

        // ---------QUERY AND DOWNLOAD COMMANDS-----------------------------------------

        public void onButtonPressed(studyLevelQuery queryInputs)
        {
            studyLevelQueries = new List<studyLevelQuery>();
            queryTools.doQuery(queryInputs,dir);
        }

        public void onStudyButtonPressed(seriesLevelQuery queryInputs)
        {
            seriesLevelQueries = new List<seriesLevelQuery>();
            queryTools.doQuery(queryInputs,dir);
        }

        public void onSeriesButtonPressed(seriesLevelQuery queryResults)
        {
          //  downloadedFileInfo = queryResults;
            queryTools.downloadSeries(queryResults);
            // act on the listener based on dir
        }


        // ---------EVENT HANDLERS-----------------------------------------


        public void onCreated(query queryResults)
        {

            if (queryResults.GetType().Name.Equals("studyLevelQuery"))
            {
                studyLevelQueries.Add((studyLevelQuery)queryResults);
                raiseStudyArrived((studyLevelQuery)queryResults);

            }

            if (queryResults.GetType().Name.Equals("seriesLevelQuery"))
            {
                seriesLevelQueries.Add((seriesLevelQuery)queryResults);
                raiseSeriesArrived((seriesLevelQuery)queryResults);

            }

        }

        public void onDownloaded(string fullPath)
        {
            string dir = @"C:\Users\daniele\Lavoro\Dicom\Listener";
            raiseDownloadArrived(fullPath);
        }

    }
}

using QueryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Utilities;

namespace ExplorerManager
{
    public class explorerManager : Publisher
    {
        public queryManager studyQueryManager;
        studyLevelQuery studyQuery;

        public queryManager seriesQueryManager;
        seriesLevelQuery seriesQuery;

        public downloadManager d;

        public explorerManager()
        {

            studyQueryManager = new queryManager(@"C:/Users/daniele/Desktop/QUERYRESULTS");
            seriesQueryManager = new queryManager(@"C:/Users/daniele/Desktop/SERIESQUERYRESULTS");

            studyQueryManager.studyArrived += onStudyQueryArrived;
            seriesQueryManager.seriesArrived += onSeriesQueryArrived;
        }

        // search field action
        public void onButtonPressed(string patientName)
        {
            studyQuery = new studyLevelQuery();
            studyQuery.PatientName = patientName;
            studyQuery.fill();

            studyQueryManager.onButtonPressed(studyQuery);
        }

        public void onStudyButtonPressed(studyLevelQuery studyQueryResults)
        {
            seriesQuery = new seriesLevelQuery(studyQueryResults);
            seriesQueryManager.onStudyButtonPressed(seriesQuery);
        }

        public void onDownloadButtonPressed()
        {
         //   d = new downloadManager();
            //d.Event += onDownloaded;
        }



        public void onStudyQueryArrived(studyLevelQuery queryResults)
        {
            studyQuery = queryResults;
            raiseStudyArrived(queryResults);
        }

        public void onSeriesQueryArrived(seriesLevelQuery queryResults)
        {            
            seriesQuery = queryResults;
            raiseSeriesArrived((queryResults));
        }

        public void onDownloaded(studyLevelQuery downloadResults)
        {
            //RaiseEvent(downloadResults);
        }

    }

}

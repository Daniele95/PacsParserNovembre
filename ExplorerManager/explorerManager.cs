using QueryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
           
        }

        public void onButtonPressed(string patientName)
        {
            studyQuery = new studyLevelQuery();
            studyQuery.PatientName = patientName;
            studyQuery.fill();

            studyQueryManager = new queryManager(@"C:/Users/daniele/Desktop/QUERYRESULTS");
            studyQueryManager.studyArrived += onStudyQueryArrived;
            studyQueryManager.onButtonPressed(studyQuery);
        }

        public void onStudyButtonPressed()
        {
            seriesQuery = new seriesLevelQuery(studyQuery);

            seriesQueryManager = new queryManager(@"C:/Users/daniele/Desktop/SERIESQUERYRESULTS");
            seriesQueryManager.seriesArrived += onSeriesQueryArrived;
            seriesQueryManager.onStudyButtonPressed(seriesQuery);
        }

        public void onDownloadButtonPressed()
        {
            d = new downloadManager();
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
           // RaiseEvent(downloadResults);
        }

    }

}

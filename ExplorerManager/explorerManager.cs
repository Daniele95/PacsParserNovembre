﻿using QueryManager;
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
        queryManager q;
        downloadManager d;
        public explorerManager()
        {
            q = new queryManager();
            q.Event += onCreated;

            d = new downloadManager();
            d.Event += onDownloaded;

        }

        public void onButtonPressed(string patientName)
        {
            studyLevelQuery queryInputs = new studyLevelQuery();
            queryInputs.PatientName = patientName;
            queryInputs.fill();
            q.onButtonPressed(queryInputs);
        }

        public void onStudyButtonPressed(studyLevelQuery downloadInputs)
        {
            d.onStudyButtonPressed(downloadInputs);
        }

        public void onCreated(studyLevelQuery queryResults)
        {
            RaiseEvent(queryResults);
        }
        public void onDownloaded(studyLevelQuery downloadResults)
        {
            RaiseEvent(downloadResults);
        }

    }

}

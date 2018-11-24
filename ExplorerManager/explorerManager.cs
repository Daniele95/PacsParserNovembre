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
        queryManager q;
        public explorerManager()
        {
            q = new queryManager();
            q.Event += onCreated;
        }

        public void onButtonPressed(string patientName)
        {
            studyLevelQuery queryInputs = new studyLevelQuery();
            queryInputs.PatientName = patientName;
            queryInputs.fill();
            q.onButtonPressed(queryInputs);

        }

        public void onCreated(studyLevelQuery queryResults)
        {
            RaiseEvent(queryResults);
        }

    }

}

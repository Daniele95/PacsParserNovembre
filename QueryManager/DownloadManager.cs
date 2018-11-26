using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryTools;
using Utilities;

namespace QueryManager
{

    public class downloadManager : Publisher
    {
        public void onStudyButtonPressed(studyLevelQuery downloadInputs)
        {
            queryTools.downloadStudy(downloadInputs);
        }
        public void onCreated(studyLevelQuery queryResults)
        {
            RaiseEvent(queryResults);
        }
    }
}

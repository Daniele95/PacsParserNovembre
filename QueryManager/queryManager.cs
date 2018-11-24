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
            studyLevelQuery queryData = new studyLevelQuery();

            queryData.insert("QueryRetrieveLevel", "STUDY");
            queryData.insert("PatientName", "Doe*");
            queryData.insert("PatientBirthDate", "");
            queryData.insert("PatientID", "");
            queryData.insert("Modality", "");
            queryData.insert("StudyInstanceUID", "");
            queryData.insert("StudyDate", "");
            queryData.insert("AccessionNumber", "");
            queryData.insert("StudyDescription", "");


            queryTools.doStudyLevelQuery(queryData);
        }

        public void onCreated(string a)
        {
            RaiseEvent(a);
        }

    }
}

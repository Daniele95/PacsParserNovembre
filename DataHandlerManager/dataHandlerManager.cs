using DataHandlerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DataHandlerManager
{
    public class dataHandlerManager
    {

        int retrieveData = 0;

        IncomingFileHandler incomingFileHandler;

        public dataHandlerManager()
        {   // create + init:
            incomingFileHandler = new IncomingFileHandler();
        }

        public void returnResults()
        {
            incomingFileHandler.returnResults();
        }


    }
}

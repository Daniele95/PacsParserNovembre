using DataHandlerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DataHandlerManager
{
    public class ViewData
    {
        // is called from the UI (explorer) level, and accesses the deeper DataHandlerTools

        int retrieveData = 0;

        public void retrieveFiles()
        {
            new System.Threading.Thread(() =>
            {
                GetCreatedFiles a = new GetCreatedFiles();
                retrieveData = 1;
                Console.WriteLine(retrieveData);
                System.Threading.Thread.Sleep(2000);
            }).Start();
        }

    }
}

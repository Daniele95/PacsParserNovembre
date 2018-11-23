using DataHandlerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerManager
{
    public class explorerManager
    {
        void onButtonPresset()
        {
            new System.Threading.Thread(() =>
            {
                dataHandlerManager d = new dataHandlerManager();
                d.returnResults();
            }).Start();
        }
    }
}

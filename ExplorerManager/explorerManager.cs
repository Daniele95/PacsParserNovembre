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

        public void onButtonPressed()
        {
            q.onButtonPressed();

           // new System.Threading.Thread(() =>  {

          //  }).Start();
        }

        public void onCreated( string a)
        {
            Console.WriteLine("CCCCCCCCCCCCCCCCCCCCCCCCCCCCC");
            RaiseEvent(a);
        }

    }

}

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
        public void onButtonPressed()
        {
            new System.Threading.Thread(() =>
            {
                queryManager q = new queryManager();
                q.Event += onCreated;

            }).Start();
        }

        public void onCreated( string a)
        {
            Console.WriteLine("RISULTATI ARRIVATI arrivati!!");
            RaiseEvent(a);
        }

    }
}

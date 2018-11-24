using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class studyLevelQuery
    {
        
        Dictionary<string, string> queryData = new Dictionary<string, string>();
        public void insert(string a, string b)
        {
            queryData.Add(a, b);
        }
        public Dictionary<string, string>.KeyCollection getKeys()
        {
            return queryData.Keys;
        }
        public string getElementByTag(string tag)
        {
            return queryData[tag];
        }

    }

    public abstract class Publisher
    {
        public delegate void EventHandler(string s);
        public event EventHandler Event;

        public void RaiseEvent(string s)
        {
            Event(s);
        }

    }
}

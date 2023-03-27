using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CP.useful;

namespace CP.useful
{
    public class UILog : CP.useful.SingletonMonoBehaviour<UILog>
    {
        [SerializeField]Text atext = null;
        List<string> logStr = new List<string>();
        [SerializeField] int maxLogCount = 4;
        public void Log(Object str)
        {
            Log(str.ToString());
        }

        public void Log(string str)
        {
            logStr.Insert(0, str);
            if (logStr.Count > maxLogCount)
            {
                logStr.RemoveAt(maxLogCount);
            }

            atext.text = "";
            foreach (string s in logStr)
            {
                atext.text += s + "\n";
            }
        }

        int GetLine(string str)
        {
            string before = str;
            string after = str.Replace("\n", "");
            int ret = before.Length - after.Length;
            return ret;
        }
    }
}

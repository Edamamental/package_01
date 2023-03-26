using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HudCreateSettings", menuName = "Scriptable/HudSetting")]
public class HudCreateSettings : ScriptableObject
{
    public CanvasCreateData[] CanvasCreateDataArray = null;
    public HudCreateData[] HudCreateDataArray = null;

    [System.Serializable]
    public class HudCreateData
    {
        public HudBase HudPrefab = null;
        public string CanvasKey = "Default"; 
    }

    public CanvasCreateData GetCanvasCreateData(string key)
    {
        foreach(CanvasCreateData data in CanvasCreateDataArray)
        {
            if(data.CanvasKey == key)
            {
                return data;
            }
        }

        //使用できないキャンバスを取得しにきている可能性あり。
        Debug.Assert(true);

        return null;
    }
   
    
}

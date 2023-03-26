using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MenuCreateSettings", menuName = "Scriptable/MenuSetting")]
public class MenuCreateSettings :ScriptableObject
{
    public CanvasCreateData[] CanvasCreateDataArray = null;
    public MenuCreateData[] MenuCreateDataArray = null;



[System.Serializable]
    public class MenuCreateData
    {
        public MenuBase MenuPrefab = null;
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


[System.Serializable]
    public class CanvasCreateData
    {
        public Canvas CanvasPrefab = null;
        public string CanvasKey = "Deafault";

    }

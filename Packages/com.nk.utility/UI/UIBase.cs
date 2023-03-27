using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
}

[System.Serializable]
public class CreateUIData
{
    public string CanvasKey = "";
    public UIBase UIPrefab = null;
}

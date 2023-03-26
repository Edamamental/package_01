using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStableAspect : MonoBehaviour
{

    public Camera targetCamera = null;
    public float baseWidth = 9.0f;
    public float baseHeight = 16.0f;

    void Awake()
    {
        // ベース維持
        var scaleWidth = (Screen.height / this.baseHeight) * (this.baseWidth / Screen.width);
        var scaleRatio = Mathf.Max(scaleWidth, 1.0f);
        this.targetCamera.orthographicSize *= scaleRatio;
    }
    
}

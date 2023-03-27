using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWindow : MonoBehaviour
{
    [SerializeField]Transform m_Root = null;
    
    void Start()
    {
        EnableWidow(false);
    }
    public void EnableWidow(bool value)
    {
        if(m_Root != null)
        {
            m_Root.gameObject.SetActive(value);

        }
        
    }
    public void ToggleWindow()
    {
        if(m_Root == null)
        {
            return;
        }
        if(m_Root.gameObject.activeSelf)
        {
            EnableWidow(false);
        }
        else
        {
            EnableWidow(true);
        }
    }
}

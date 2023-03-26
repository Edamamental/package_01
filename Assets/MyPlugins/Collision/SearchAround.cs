using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using useful;

public class SearchAround : MonoBehaviour
{
    [SerializeField]float m_SearchRadius = 10;
    [SerializeField]float m_UpdateIntarval = 0.25f;
    List<GameObject> m_AllObjectList = new List<GameObject>();
    [SerializeField]LayerMask m_TargetLayer = new LayerMask();
    float m_Timer = 0;




    void FixedUpdate()
    {
        if(m_Timer >= m_UpdateIntarval)
        {
            UpdateObjectList();
            m_Timer = 0;
        }
        m_Timer += Time.fixedDeltaTime;
    }

    void UpdateObjectList()
    {
        Collider[] targetCol = Physics.OverlapSphere(this.transform.position,m_SearchRadius,m_TargetLayer);
        m_AllObjectList.Clear();
        if(targetCol.Length > 0)
        {
            foreach (Collider col in targetCol)
            {
                if (col != null)
                {
                    m_AllObjectList.Add(col.gameObject);
                }
            }

        }
        
    }

    public GameObject GetNearTargetFromTag(string tag)
    {
        GameObject returnValue = null;
        foreach (GameObject obj in m_AllObjectList)
        {
            if (obj != null && obj.tag == tag)
            {
                if(returnValue == null)
                {
                    returnValue = obj;
                }else
                {
                    returnValue = GetNearObj(returnValue,obj);
                }
                
            }
        }
        return returnValue;
    }

    public GameObject GetNearObj(GameObject a , GameObject b)
    {
        if(GetDist(this.gameObject,a) > GetDist(this.gameObject,b))
        {
            return b;

        }
        return a; 
    }

    public float GetDist(GameObject a, GameObject b)
    {
        return (a.gameObject.transform.position - this.transform.position).magnitude;
    }

    public List<GameObject> GetObjectListFromTag(string tag)
    {
        List<GameObject> objectList = new List<GameObject>();
        foreach(GameObject obj in m_AllObjectList)
        {
            if(obj != null && obj.tag == tag)
            {
                objectList.Add(obj);
            }
        }
        return objectList;
    }

    //マイフレーム行うと重い
    public List<T> GetObjectList<T>() where T : InterfaceBase
    {
        List<T> objectList = new List<T>();
        foreach (GameObject obj in m_AllObjectList)
        {
            if(obj != null)
            {
                T v = obj.GetComponent<T>();
                if (v != null)
                {
                    objectList.Add(v);
                }

            }
            
        }
        return objectList;

    }

    
}

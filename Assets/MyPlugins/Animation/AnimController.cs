using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimController
{
    [SerializeField] string m_AnimatorRootTransName = null;
    [HideInInspector] public Animator m_Anim = null;
    [SerializeField] List<AnimData> m_AnimDataList = null;

    GameObject m_Owner = null;

    public void SetUp(GameObject owner)
    {
        m_Owner = owner;
        foreach (Transform trans in m_Owner.GetComponentsInChildren<Transform>())
        {
            if (trans.name == m_AnimatorRootTransName)
            {
                m_Anim = trans.GetComponent<Animator>();
            }
        }
        Debug.Assert(m_Anim != null, "Cant Search Animator");
    }

    public void UpdateAnimData(string key)
    {
        if(m_Anim == null)
        {
            return;
        }
        foreach(AnimData data in m_AnimDataList)
        {
            if(key == data.m_Key)
            {
                switch (data.m_Type)
                {
                    case AnimType.Trigger:
                        SetAnimTrigger(data.m_Key);
                        break;

                    case AnimType.Bool:
                        SetAnimBool(data.m_Key, data.m_Bool);
                        break;

                    case AnimType.Float:
                        SetAnimFloat(data.m_Key, data.m_FloatValue);
                        break;

                    case AnimType.Int:
                        SetAnimInt(data.m_Key, data.m_Int);
                        break;
                 }
            }
        }
    }

    void SetAnimTrigger(string key)
    {
        m_Anim.SetTrigger(key);
    }

    void SetAnimBool(string key, bool value)
    {
        m_Anim.SetBool(key, value);
    }

    void SetAnimFloat(string key , float value)
    {
        m_Anim.SetFloat(key, value);
    }

    void SetAnimInt(string key, int value)
    {
        m_Anim.SetInteger(key, value);
    }
    
}

public enum AnimType
{
    None,
    Trigger,
    Bool,
    Float,
    Int
}


[System.Serializable]
public class AnimData
{
    public string m_Key = "None";
    public AnimType m_Type = AnimType.None;

    public float m_FloatValue = 0;
    public bool m_Bool = false;
    public int m_Int = 0;
}

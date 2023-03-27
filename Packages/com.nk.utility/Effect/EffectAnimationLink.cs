using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimationLink : MonoBehaviour
{
    [System.Serializable]
    class EffectData
    {
        public string key = "ef_none";
        public BaseEffectCntroller EfController = null;
    }

    [SerializeField]List<EffectData> m_EffectDataList = null;

    public void PlayEffect(string key)
    {
        foreach(EffectData data in m_EffectDataList)
        {
            if(key == data.key)
            {
                data.EfController.PlayEffect();
            }
        }
    }
    
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrlPlayAtPos : BaseEffectCntroller
{
    public override void PlayEffect()
    {
        //EffectManager.Instance.PlayAtPos(base.m_SpawnEffectPrefab, this.transform.position, this.transform.rotation);
        m_ParticleObj.transform.position = this.transform.position;
        m_ParticleObj.transform.rotation = this.transform.rotation;

        m_ParticleObj.gameObject.SetActive(true);
        base.StartCoroutine(WaitForPlayEffect(m_ParticleObj));
    }
}

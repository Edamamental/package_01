using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEffectCntroller : MonoBehaviour
{
    [SerializeField] protected ParticleSystem m_SpawnEffectPrefab = null;
    protected ParticleSystem m_ParticleObj = null;
    public abstract void PlayEffect();

    private void OnEnable()
    {
        m_ParticleObj = Instantiate(m_SpawnEffectPrefab, this.transform.position, this.transform.rotation,this.transform);
        m_ParticleObj.gameObject.SetActive(false);
    }

    public IEnumerator WaitForPlayEffect(ParticleSystem particle)
    {
        yield return new WaitWhile(() => particle.IsAlive(true));
        m_ParticleObj.gameObject.SetActive(false);
        yield break;
    }
}

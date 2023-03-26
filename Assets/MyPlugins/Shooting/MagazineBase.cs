using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineBase : MonoBehaviour
{
	[SerializeField] protected BulletBase m_BulletPrefab = null;
	[SerializeField] protected int m_MaxCount = 10;
	protected int m_CurrentCount = 0;
	[SerializeField] protected float m_ReloadTime = 1;

	float m_ReloadStartTime = 0;
	public bool IsReload { get { return (Time.timeSinceLevelLoad - m_ReloadStartTime) <= m_ReloadStartTime; } }

	public BulletBase UseBullet()
	{
		if (m_CurrentCount <= 0)
		{
			return null;
		}

		m_CurrentCount--;
		return Instantiate(m_BulletPrefab); 
	}
	public virtual void Reload()
	{
		if (!IsReload)
		{
			m_ReloadStartTime = Time.timeSinceLevelLoad;
		}
	}
	public virtual void Refil()
	{
		m_CurrentCount = m_MaxCount;
	}
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
	[SerializeField] MagazineBase m_MagazineBase = null;
	[SerializeField] Transform m_MuzzleTrans = null;

	[SerializeField] float m_IntarbalTime = 0.25f;
	[SerializeField] float m_LatestShootTime = 0;
	bool CanShoot { get { return Time.timeSinceLevelLoad - m_LatestShootTime >= m_IntarbalTime; } }

	public void Update()
	{
		if (CanShoot)
		{
			ShootBullet();
		}
	}

	public void ShootBullet()
	{
		if (!m_MagazineBase.IsReload)
		{
			BulletBase aBullet = m_MagazineBase.UseBullet();
			if (aBullet != null)
			{
				aBullet.transform.position = m_MuzzleTrans.position;
				aBullet.transform.rotation = m_MuzzleTrans.rotation;
				m_LatestShootTime = Time.timeSinceLevelLoad;
			}
			else
			{
				m_MagazineBase.Refil();
			}
		}
	}
}

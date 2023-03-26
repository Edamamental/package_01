using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
	float m_LifeTime = 13;
	[SerializeField] float speed = 40;

	void Update()
    {
		BulletUpdate();
	}

	
	protected virtual void BulletUpdate()
	{
		m_LifeTime -= Time.deltaTime;
		if(m_LifeTime < 0)
		{
			DeleteBullet();
		}
		this.transform.position += this.transform.forward * Time.deltaTime * speed;
	}

	protected virtual void DeleteBullet()
	{
		Destroy(this.gameObject);
	}
}

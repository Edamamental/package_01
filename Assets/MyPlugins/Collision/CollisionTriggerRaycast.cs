using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

public class CollisionTriggerRaycast<T> : CollisionTriggerBase<T> where T : HitData
{
	Vector3 m_LatestPos = Vector3.zero;
	public float m_CollsionSpherRadius = 0.5f;
	int count = 0;

	#pragma warning disable 0649
	[SerializeField] LayerMask m_HitLayerMask = new LayerMask();

	protected virtual void Start()
	{
		m_LatestPos = this.transform.position;
	}

	public void FixedUpdate()
	{
		if(count > 3)
		{
			HitCheck(this.transform.position, m_LatestPos);
			m_LatestPos = this.transform.position;
			count = 0;
		}
		

		count++;
	}

	protected override void OnTriggerEnter(Collider other)
	{
		//base.OnTriggerEnter(other);
	}
	protected override void OnTriggerStay(Collider other)
	{
		//base.OnTriggerStay(other);
	}

	protected override void OnTriggerExit(Collider other)
	{
		//base.OnTriggerExit(other);
	}

	//継承された関数
	protected override void OnEnterHitObj(Collider other, CollisionReceiverBase<T> receiver)
	{
		base.OnEnterHitObj(other, receiver);
	}

	protected override void OnStayHitObj(Collider other, CollisionReceiverBase<T> receiver)
	{
		base.OnStayHitObj(other, receiver);
	}

	protected override void OnExitHitObj(Collider other, CollisionReceiverBase<T> receiver)
	{
		base.OnExitHitObj(other, receiver);
	}


	//レイキャストを使ってヒットをチェック
	//レイキャストは初期位置で既に重なっていると採れないため、オーバーラップスフィアその場合は保管する。
	//対象のreceiverを持つ場合はOnEnterHitObjが呼び出される
	void HitCheck(Vector3 currentPos, Vector3 latestPos)
	{
		CollisionReceiverBase<T> receiver = null;
		Collider aColl = null;
		Ray aRay = new Ray(latestPos, currentPos - latestPos);
		RaycastHit raycastHit = new RaycastHit();
		if (Physics.SphereCast(aRay, m_CollsionSpherRadius, out raycastHit, (currentPos - latestPos).magnitude, m_HitLayerMask))
		{
			receiver = GetReciever(raycastHit.collider) as CollisionReceiverBase<T>;
			if (receiver != null)
			{
				hitData.HitPos = raycastHit.point;
				aColl = raycastHit.collider;
			}
		}
		else
		{
			foreach (Collider acoll in Physics.OverlapSphere(currentPos, m_CollsionSpherRadius, m_HitLayerMask))
			{
				if (acoll.enabled)
				{
					receiver = GetReciever(acoll) as CollisionReceiverBase<T>;
					if (receiver != null)
					{
						hitData.HitPos = acoll.ClosestPointOnBounds(this.transform.position);
						aColl = acoll;
						break;
					}
				}
			}
		}
		ChangeHitState(aColl, receiver);
		latestCollider = aColl;
	}

	CollisionReceiverBase<T> keepReceiver = null;
	Collider latestCollider = null;

	void ChangeHitState(Collider other, CollisionReceiverBase<T> receiver)
	{
		//STAY
		if (receiver && keepReceiver == receiver)
		{
			OnStayHitObj(other, receiver);
		}
		else
		{
			//ENTER
			if (keepReceiver == null && receiver)
			{
				OnEnterHitObj(other, receiver);
			}
			//EXIT
			else if (keepReceiver && receiver == null)
			{
				OnExitHitObj(other, keepReceiver);
			}
		}
		keepReceiver = receiver;
	}
}

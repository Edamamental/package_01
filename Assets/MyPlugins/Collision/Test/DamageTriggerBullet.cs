using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

public class DamageTriggerBullet : CollisionTriggerRaycast<MyCollisionSystem.DamageData>
{
	

	protected override void OnEnterHitObj(Collider other, CollisionReceiverBase<MyCollisionSystem.DamageData> receiver)
	{
		base.OnEnterHitObj(other, receiver);
		Destroy(base.Owner);
	}
}

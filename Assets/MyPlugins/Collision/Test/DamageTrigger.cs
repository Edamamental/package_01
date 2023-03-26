using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

public class DamageTrigger : CollisionTriggerBase<MyCollisionSystem.DamageData>
{

	protected override void OnStaySomething(Collider other)
	{
		base.OnStaySomething(other);
		//Destroy(Owner.gameObject);
	}
	protected override void OnEnterHitObj(Collider other, CollisionReceiverBase<DamageData> receiver)
	{
		base.OnEnterHitObj(other, receiver);
	}
}

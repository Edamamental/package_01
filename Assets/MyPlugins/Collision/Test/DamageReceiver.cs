using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

public class DamageReceiver : CollisionReceiverBase<MyCollisionSystem.DamageData>
{
	bool IsAlive = true;
	[SerializeField] float MaxLifePoint = 10;
	float currentLifePoint = 0;
	[SerializeField]float destroyDelay = 1;
	[SerializeField]bool noObjectDestry = false;

    public void CollisionSleep()
	{
		foreach(Collider col in GetComponents<Collider>())
		{
			col.enabled = false;
		}
	}
    public void CollisionActivate()
    {
        foreach (Collider col in GetComponents<Collider>())
        {
            col.enabled = true;
        }
    }

	private void Start()
	{
		IsAlive = true;
		currentLifePoint = MaxLifePoint;
	}

	public override void EnterCol(MyCollisionSystem.DamageData data)
	{
		currentLifePoint -= data.Power;
		if(currentLifePoint <= 0 && IsAlive)
		{
			Death();
			Delete();
		}
	}

	public override void ExitCol(MyCollisionSystem.DamageData data){}
	public override void StayCol(MyCollisionSystem.DamageData data){}

	protected virtual void Death()
	{
		IsAlive = false;
		Owner.SendMessage("Death", SendMessageOptions.DontRequireReceiver);
	}
	protected virtual void Delete()
	{
		if (!noObjectDestry)
		{
			Destroy(Owner.gameObject, destroyDelay);
		}
		else
		{
			Destroy(this);
		}
	}
}

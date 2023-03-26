using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

public class CatchReceiver : CollisionReceiverBase<CatchData>
{
	protected override void SetUp()
	{
        
	}

	public override void EnterCol(CatchData data)
	{
		Destroy(data.TargetOwner);
	}
	public override void ExitCol(CatchData data){}
	public override void StayCol(CatchData data){}
}

public interface IInventory
{

	
}

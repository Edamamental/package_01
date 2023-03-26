using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

namespace MyCollisionSystem
{
	[System.Serializable]
	public abstract class HitData
	{
		public GameObject TargetOwner = null;
		public Vector3 HitPos = Vector3.zero;
	}
}


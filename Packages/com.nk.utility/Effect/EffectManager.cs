using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.useful;

namespace CP.useful
{
	public class EffectManager : SingletonMonoBehaviour<EffectManager>
	{
		[SerializeField] GameObject[] VFXPrefabs = null;

		public void PlayAtPos(string name, Vector3 pos)
		{
			foreach (GameObject obj in VFXPrefabs)
			{
				if (obj.name == name)
				{
					Instantiate(obj, pos, Quaternion.identity);
				}
			}
		}

		public void PlayAtPos(string name, Vector3 pos, Quaternion rot)
		{
			foreach (GameObject obj in VFXPrefabs)
			{
				if (obj.name == name)
				{
					Instantiate(obj, pos, rot);
				}
			}
		}
	}
}


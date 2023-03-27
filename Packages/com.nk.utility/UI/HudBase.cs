using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudBase : MonoBehaviour
{
	//[SerializeField]HudManager.HudName hudName = HudManager.HudName.None;
	//public HudManager.HudName HudName { get { return hudName; } }

	public virtual void HudSleep()
	{
		Destroy(this.gameObject);
	}

	public virtual void HudActivate(){}
    
}

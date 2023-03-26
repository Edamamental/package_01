using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimBase
{
	public AnimBase(GameObject _owner, Animator _anim)
	{
		owner = _owner;
		anim = _anim;
	}
	static GameObject owner = null;
	Animator anim = null;

	public virtual void SetTrigger(string name)
	{
		anim.SetTrigger(name);
	}
	public virtual void SetBool(string name, bool value)
	{
		anim.SetBool(name, value);
	}
	public virtual void SetInt(string name, int value)
	{
		anim.SetInteger(name, value);
	}
	public virtual void SetFloat(string name, int value)
	{
		anim.SetFloat(name, value);
	}

	IEnumerator DelayFunction<T>(float delay, Action<T> action, T t)
	{
		yield return new WaitForSeconds(delay);
		action(t);
	}
}

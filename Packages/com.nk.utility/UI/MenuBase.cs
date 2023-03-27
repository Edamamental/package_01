using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CP.MyTouchInput;

public class MenuBase : UIBase
{
	[SerializeField]float closeTrandisionTime = 0.0f;
	Coroutine col = null;
	private void Awake()
	{
		this.gameObject.SetActive(false);
	}

	protected virtual void OnDisable()
	{
        //LocalEvent.DecideButtonEvent -= Decide;
        //localButtonEvent.ButtonEvent -= ButtomDown;
		//TouchEvent.ButtonDownEvent -= ButtomDown;

	}

	protected virtual void OnEnable()
	{
        //LocalEvent.DecideButtonEvent += Decide;
        //localButtonEvent.ButtonEvent += ButtomDown;
		//TouchEvent.ButtonDownEvent -= ButtomDown;
	}

	protected virtual void Update(){}

	protected virtual IEnumerator MenuUupdate()
	{
		yield break;
	}
	protected virtual IEnumerator CloseTrandisionUpsate()
	{
        if (col != null)
        {
            StopCoroutine(col);
        }
		yield return new WaitForSeconds(closeTrandisionTime);
        ExitMenu();
        gameObject.SetActive(false);
		yield break;
	}
	protected virtual void EnterMenu() { }
	protected virtual void ExitMenu() { }

	public void MenuActive()
	{
		gameObject.SetActive(true);
		EnterMenu();
		if(col == null)
		{
			col = StartCoroutine(MenuUupdate());
		}
		else
		{
			Debug.Log("warning");
		}
		
	}
	public void MenuSleep()
	{

        StartCoroutine(CloseTrandisionUpsate());
	}

	//ボタンから入力イベントを受け取る。
	protected virtual void Decide(string key){}

	protected virtual void ButtomDown(string key)
	{
		if(!gameObject.activeSelf)
		{
			return;
		}
	}
}

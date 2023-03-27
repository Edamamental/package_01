using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.useful;

public class HudManager : SingletonMonoBehaviour<HudManager>
{
	[SerializeField] List<HudBase> hudList = new List<HudBase>();
	[SerializeField] HudCreateSettings hudeCreateSetting = null;
	List<CanvasData> CanvasDataList = new List<CanvasData>();

	public enum HudName
	{
		None,
		HudScoreCounter
	}

	override protected void Awake() 
	{
		base.Awake();
        /*
                if(hudeCreateSetting != null)
                {
                    foreach(HudCreateSettings.HudCreateData data in hudeCreateSetting.HudCreateDataArray)
                    {
                        CanvasCreateData CreataCanvasData = hudeCreateSetting.GetCanvasCreateData(data.CanvasKey);
                        Canvas canvas = CreateCanvas(CreataCanvasData);

                        Instantiate(data.HudPrefab,canvas.transform,false);
                    }
                }
		*/
    }

	Canvas CreateCanvas(CanvasCreateData data)
	{
		//生成ずみのキャンバスデータを確認してキーと一致するものが合ったらそれを返す。
        foreach (CanvasData canvasData in CanvasDataList)
        {
			if(canvasData.CanvasKey == data.CanvasKey)
			{
				return canvasData.Canvas;
			}
        }
		//キャンバスがまだ生成されてなかったら以下の処理をする
		Canvas aCanvas =　Instantiate(data.CanvasPrefab,this.transform,false);
		//キャンバスリストにデータを追加
		CanvasDataList.Add(new CanvasData(aCanvas,data.CanvasKey));
		return aCanvas;
	}

	public HudBase CreateHud<T>() where T : HudBase
	{
		if(hudeCreateSetting != null)
		{
            foreach (HudCreateSettings.HudCreateData data in hudeCreateSetting.HudCreateDataArray)
            {
				if(data.HudPrefab.GetType() == typeof(T))
				{
                    CanvasCreateData CreataCanvasData = hudeCreateSetting.GetCanvasCreateData(data.CanvasKey);
                    Canvas canvas = CreateCanvas(CreataCanvasData);

                    return Instantiate(data.HudPrefab, canvas.transform, false);
				}
            }
		}
		return null;
	}

    public HudBase CreateHudPos<T>(Vector3 pos) where T : HudBase
    {
		HudBase hud = CreateHud<T>() as T;
		if(hud != null)
		{
			hud.transform.position = pos;
			return hud;
		}
        return null;
    }

    public HudBase CreateHudWorldPos<T>(Vector3 pos) where T : HudBase
    {
        HudBase hud = CreateHud<T>() as T;
        if (hud != null)
        {
			//仮修理のためコメントアウト
            //hud.transform.position = GameManager.mainCam.WorldToScreenPoint(pos);
            return hud;
        }
        return null;
    }

	public T GetHud<T> ()  where T :HudBase 
	{
		foreach(HudBase hud in hudList)
		{
			if(hud.GetType() == typeof(T))
			{
				return hud as T;
			}
		}
		return null;
	}
}

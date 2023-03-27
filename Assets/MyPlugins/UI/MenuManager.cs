using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : CP.useful.SingletonMonoBehaviour<MenuManager>
{
	[SerializeField]MenuCreateSettings menuCreateSetting = null;

	List<CanvasData> CanvasDataList = new List<CanvasData>();

    


	protected override void Awake() 
	{
		base.Awake();
		if(menuCreateSetting != null)
		{
			foreach(MenuCreateSettings.MenuCreateData data in menuCreateSetting.MenuCreateDataArray)
			{
				//キャンバス作成用のデータをキャンバスキーから取得
                CanvasCreateData CreataCanvasData = menuCreateSetting.GetCanvasCreateData(data.CanvasKey);

				//キャンバスの作成。作成済みの時はすでにあるものを返す。名前変えても良いかも
				Canvas canvas = CreateCanvas(CreataCanvasData);

				//メニュープレハブを指定キャンバスに作成してリストに登録
				menuList.Add(Instantiate(data.MenuPrefab,canvas.transform,false));
			}
		}
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


	[SerializeField]List<MenuBase> menuList = new List<MenuBase>();

	public T GetMenu<T>() where T : MenuBase
	{
		foreach(MenuBase amenu in menuList)
		{
			if(amenu.GetType() == typeof(T))
			{
				return amenu as T;
			}
		}
		return null;
	}
}

 public class CanvasData
{
	public CanvasData(Canvas canvas, string key)
	{
		this.Canvas = canvas;
		this.CanvasKey = key;
	}
	public Canvas Canvas = null;
	public string CanvasKey = "";
}

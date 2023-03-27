using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using localSystem;
using UnityEngine.UI;


//ToDo:カーニング対応とスケール対応をする
namespace localSystem
{
	public class SpriteNum : MonoBehaviour
	{
		[SerializeField] SpriteSettings spriteSettings = null;
		[SerializeField] Image[] numbImgs = null;

		[SerializeField] float trachking = 1;
        [SerializeField] int defaultValue = 0;
		public enum align
		{
			right,
			center,
			left
		}
		[SerializeField] align hAlign = align.right;

        private void Start()
        {
            //ShowNum(defaultValue);
        }

        [ContextMenu("set")]
        void DebugSetNum()
        {
            ShowNum(defaultValue);
        }

        public void ShowNum(int num)
		{
			//数字を各桁毎の処理できるデータクラスに変換
			NumData nData = new NumData(num);

			//表示する数値の最大桁
			int maxDegit = nData.Degit;

			RectTransform trans = this.transform as RectTransform;
			trans.sizeDelta = new Vector2(0,trans.sizeDelta.y);

			//すべてのイメージに対して処理をしないといけないのでイメージの配列をループで回す
			for (int i = 0; i < numbImgs.Length; i++)
			{
				int degit = GetDegitFromIndex(i);
				int value = nData.GetNum(degit);

				if(value >= 0)
				{
					numbImgs[i].gameObject.SetActive(true);
					numbImgs[i].rectTransform.anchoredPosition = GetPos(numbImgs[i].rectTransform,GetDegitFromIndex(i),nData);
					numbImgs[i].sprite = spriteSettings.SpriteDict.GetValue(value.ToString());
					trans.sizeDelta = new Vector2(trans.sizeDelta.x + numbImgs[i].rectTransform.sizeDelta.x, trans.sizeDelta.y);
				}
				else
				{
					//表示すべき数字入ってない場合は表示をOFFする
					numbImgs[i].gameObject.SetActive(false);
				}
			}
		}

		//ToDo:アラインに応じて変更する
		Vector2 GetPos(RectTransform trans,int degit,NumData numData)
		{
            if(hAlign == align.center)
            {
				/*
                if (numData.Degit.IsEven())
                {
                    //センターになるデジットを算出してそこからの＋マイナスオフセットを掛ける偶数の場合はそこから半分ずらす
                    int centerDegit = Mathf.CeilToInt((float)numData.Degit / 2);
                    int v = degit - centerDegit;
                    return trans.sizeDelta.x * -Vector3.right * (v) - Vector3.right * trachking * v + Vector3.right * trans.sizeDelta.x *0.5f;
                }
                else
                {
                    //センターになるデジットを算出してそこからの＋マイナスオフセットを掛ける
                    int centerDegit =  Mathf.CeilToInt((float)numData.Degit / 2);
                    int v = degit - centerDegit;
                    return trans.sizeDelta.x * -Vector3.right * (v) - Vector3.right * trachking * v;
                }
				*/
				//パッケージ移行につき一時的にOFF
				return Vector2.zero;
            }
            else if(hAlign == align.left)
            {
                return trans.sizeDelta.x * Vector2.right * (numData.Degit -degit) + Vector2.right * trachking * (numData.Degit - degit);
            }
            else
            {
                return trans.sizeDelta.x * -Vector2.right * (degit - 1) - Vector2.right * trachking * (degit - 1);
            }
		}

		int GetDegitFromIndex(int index)
		{
			return index + 1;
		}

		int GetIndexFromDegit(int degit)
		{
			return degit - 1;
		}

	}

	public class NumData
	{
		int[] nums = null;
		int defaultValue = 0;
		int m_Degit = 0;

		public int Degit { get { return m_Degit; } }
		public int Value { get { return defaultValue; } }

		public NumData(int value)
		{
			SetNum(value);
		}

        //値を各桁事に配列に入れる ０=桁１
		int[] GetNumArray(int value)
		{
			//桁数を取得
			int degit = m_Degit;

			//保存用入れるを用意
			int[] nums = new int[degit];

			//計算用に数値を一時変数へ保管
			int num = value;
			for (int i = degit; i > 0; i--)
			{
				int aDegit = Pow(10, (i - 1));
				nums[i-1] = num / aDegit;
				num = value % aDegit;
			}
			nums[0] = num;
			return nums;
		}

		public void SetNum(int value)
		{
			//保存されている数値
			defaultValue = value;

			//桁数の保存
			m_Degit = GetDegit(value);

			//数値用配列を作成
			this.nums = GetNumArray(value);
		}

		//指定した桁の数値を取得
		public int GetNum(int degit)
		{ 
			if(degit <= m_Degit)
			{
				return nums[degit - 1];
			}
			return -1;	
		}

        //数値を指定回数乗算する
		static int Pow(int v1, int v2)
		{
			int value = v1;
			for (int i = 1; i < v2; i++)
			{
				value = value * v1;
			}
			return value;
		}

        //数値から桁数を取得する関数
		public static int GetDegit(int num)
		{
			int degit = 0;
            do
            {
                num /= 10;
                degit++;
            }
            while (num != 0);
            return degit;
		} 
		
	}
}





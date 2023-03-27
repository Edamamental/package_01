using System.Collections.Generic;
using UnityEngine;

namespace CP.useful
{
	[System.Serializable]
	public class SerializDic<T, T1, T2> where T : SKeyValuePair<T1, T2>
	{
		public T[] pair;

		public T1[] Keys()
		{
			//キーの配列を返す
			T1[] ReturnValues = new T1[pair.Length];
			for (int i = 0; i < ReturnValues.Length; i++)
			{
				ReturnValues[i] = pair[i].Key;
			}
			return ReturnValues;
		}
		//バリューの配列を返す
		public T2[] Values()
		{
			T2[] ReturnValues = new T2[pair.Length];
			for (int i = 0; i < ReturnValues.Length; i++)
			{
				ReturnValues[i] = pair[i].Value;
			}
			return ReturnValues;
		}

		public T2 GetValue(T1 key)
		{
			T2[] Array = Values();
			for (int i = 0; i < Array.Length; i++)
			{
				if (EqualityComparer<T1>.Default.Equals(pair[i].Key, key))
				{
					return Array[i];
				}
			}
			return default(T2);
		}
	}
	//SerializeDicを継承したくらす。インスペクタでGenericを表示で着ないのでパターンを追加する度にこれを作る
	[System.Serializable]
	public class SerializeDicGameObject : SerializDic<SkeyValuePairStrGameObject, string, GameObject> { }
	[System.Serializable]
	public class SerializeDicTransform : SerializDic<SkeyValuePairStrTransform, string, Transform> { }
	[System.Serializable]
	public class SerializeDicIntArray : SerializDic<SkeyValuePairStrIntArray, string, int[]> { }
	[System.Serializable]
	public class SerializeDicTextAsset : SerializDic<SkeyValuePairStrTextAsset, string, TextAsset[]> { }
	[System.Serializable]
	public class SerializeDicSprite : SerializDic<SkeyValuePairStrSprite, string, Sprite> { }

	//ディクショナリーっぽいものをインスペクターで表示させるためのクラス
	[System.Serializable]
	public class SKeyValuePair<T1, T2>
	{
		public T1 Key;
		public T2 Value;
	}
	[System.Serializable]
	public class SkeyValuePairStrGameObject : SKeyValuePair<string, GameObject> { }
	[System.Serializable]
	public class SkeyValuePairStrTransform : SKeyValuePair<string, Transform> { }
	[System.Serializable]
	public class SkeyValuePairStrIntArray : SKeyValuePair<string, int[]> { }
	[System.Serializable]
	public class SkeyValuePairStrTextAsset : SKeyValuePair<string, TextAsset[]> { }
	[System.Serializable]
	public class SkeyValuePairStrSprite : SKeyValuePair<string, Sprite> { }



}

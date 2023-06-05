using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CP.useful
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour
	{
		public bool IsDontDestory = false;

		static T m_Singlton;
		public static T Instance { get { return m_Singlton; } }
		[SerializeField]bool IsDonotDestoryChild = false;

		protected virtual void Awake()
		{
			if(m_Singlton == null)
			{
				if(IsDontDestory)
				{
					DontDestroyOnLoad(this.gameObject);
				}
				MakeSingleton();
			}
			else
			{
				Destroy(this.gameObject);
			}
		}

		public virtual void OnDestroy()
		{
			if (!IsDontDestory)
			{
				if(!IsDonotDestoryChild)
				{
					m_Singlton = default(T);
				}
			}
		}

		public virtual void MakeSingleton()
		{
			m_Singlton = this.GetComponent<T>();
		}
	}

}

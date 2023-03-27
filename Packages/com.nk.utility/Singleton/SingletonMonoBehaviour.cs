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

		int debugCount = 0;

		protected virtual void Awake()
		{


			if (IsDontDestory && m_Singlton == null)
				DontDestroyOnLoad(this.gameObject);

			MakeSingleton();
		}

		public virtual void OnDestroy()
		{
			if (!IsDontDestory)
				m_Singlton = default(T);
		}

		public virtual void MakeSingleton()
		{
			debugCount++;

			if (m_Singlton == null)
			{
				m_Singlton = this.GetComponent<T>();
			}
			else if (IsDontDestory)
			{
				Destroy(this.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}

}

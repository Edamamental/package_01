using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalEventSystem
{
	public static class EventManager
	{
		public delegate void myEvent();
		public delegate void myEvent<T>(T t);
		public delegate void myEvent<T1, T2>(T1 t1, T2 t2);
		public delegate void myEvent<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
		public delegate void myEvent<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);
	}
}


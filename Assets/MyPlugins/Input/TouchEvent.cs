using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LocalEventSystem;
using CP.MyTouchInput;

namespace CP.MyTouchInput
{
	public static class TouchEvent
	{
		public static EventManager.myEvent<TouchInfo> TouchDownEvent;
		public static void CallToucDown(TouchInfo touchinfo)
		{
			if (TouchDownEvent != null)
			{
				TouchDownEvent(touchinfo);
			}
		}

		public static EventManager.myEvent<TouchInfo> TouchUpEvent;
		public static void CallToucUp(TouchInfo touchinfo)
		{
			if (TouchUpEvent != null)
			{
				TouchUpEvent(touchinfo);
			}
		}

		public static EventManager.myEvent<TouchInfo> TouchTouchingEvent;
		public static void CallTouching(TouchInfo touchinfo)
		{
			if (TouchTouchingEvent != null)
			{
				TouchTouchingEvent(touchinfo);
			}
		}

		public static EventManager.myEvent<string> ButtonDownEvent;
		public static void CallButtonDownEvent(string key)
		{
			if (ButtonDownEvent != null)
			{
				ButtonDownEvent(key);
			}
		}
	}
}
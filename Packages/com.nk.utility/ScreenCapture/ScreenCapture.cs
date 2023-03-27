using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace localSystem{
	public static class ScreenCapture
	{
		#if UNITY_EDITOR
		[MenuItem ("DebugTools/ScreenShot/PrintScreen #&p")]
		private static void RunScreenCapture ()
		{
			string saveFilePath = "ScreenShot/";
			if (!Directory.Exists("ScreenShot"))
				Directory.CreateDirectory("ScreenShot");

			string fileName = Application.productName + "_SS_";
			string time = System.DateTime.Now.Month.ToString ("D2") + System.DateTime.Now.Day.ToString ("D2") + System.DateTime.Now.Hour.ToString ("D2") + System.DateTime.Now.Minute.ToString ("D2") + System.DateTime.Now.Second.ToString ("D2") + "_" + System.DateTime.Now.Millisecond.ToString ("D2");

			string cp_file = saveFilePath + fileName + time + ".png";

			UnityEngine.ScreenCapture.CaptureScreenshot (cp_file);
			Debug.Log ("スクリーンショットを保存:" + cp_file);
		}

		#endif
	}
}


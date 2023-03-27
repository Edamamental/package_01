using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.useful;
using CP.MyTouchInput;


namespace CP.MyTouchInput
{
    public class TouchInputManager : CP.useful.SingletonMonoBehaviour<TouchInputManager>
    {
        TouchInfo touchInfo = new TouchInfo();
        [SerializeField, Range(0.1f, 2)]
        float sensitivity = 1.0f;
        public float Sensitivity { get { return Mathf.Clamp(sensitivity, 0, 2); } }

        private void Update()
        {
            touchInfo.LatestTouchPos = touchInfo.TouchPos;
            touchInfo.TouchPos = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                touchInfo.CurrentTouchState = TouchState.Down;
                touchInfo.TouchStartPos = touchInfo.TouchPos;
                touchInfo.touchTime += Time.deltaTime;
                //LocalEvent.CallTouchDown(touchInfo);
                TouchEvent.CallToucDown(touchInfo);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                touchInfo.CurrentTouchState = TouchState.Up;
                //LocalEvent.CallTouchUp(touchInfo);
                TouchEvent.CallToucUp(touchInfo);
            }
            else if (Input.GetMouseButton(0))
            {
                touchInfo.touchTime += Time.deltaTime;
                touchInfo.CurrentTouchState = TouchState.Touching;
                //LocalEvent.CallTouching(touchInfo);
                TouchEvent.CallTouching(touchInfo);
            }
            else
            {
                touchInfo.touchTime = 0;
                touchInfo.TouchStartPos = Vector3.zero;
                touchInfo.CurrentTouchState = TouchState.None;
            }
        }

        public static Vector3 ChangeCameraDir(Vector3 dir)
        {
            //仮しゅうり
            return Vector3.zero;
            /*
            Vector3 cameraF = Vector3.Scale(GameManager.mainCam.transform.forward, new Vector3(1, 0, 1));
            return cameraF * dir.y + GameManager.mainCam.transform.right * dir.x;
            */
        }

        public static Vector3 ChangeToWorldPos(Vector3 pos, float dist = 10)
        {
            return Vector3.zero;
            //仮修理
            //return GameManager.mainCam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, dist));
        }
    }

    public class TouchInfo
    {
        public TouchState CurrentTouchState = TouchState.None;
        public Vector3 TouchPos = Vector3.zero;
        public Vector3 TouchStartPos = Vector3.zero;
        public Vector3 LatestTouchPos = Vector3.zero;
        public float dist { get { return (TouchPos - TouchStartPos).magnitude / TouchInputManager.Instance.Sensitivity; } }

        public Vector3 CameraDir { get { return TouchInputManager.ChangeCameraDir((TouchPos - TouchStartPos).normalized); } }
        public Vector3 CameraDeltaDir { get { return TouchInputManager.ChangeCameraDir(DeltaDir.normalized); } }
        public Vector3 WoldDir{get{return TouchInputManager.ChangeToWorldPos(TouchPos) - TouchInputManager.ChangeToWorldPos(LatestTouchPos); }}
        public Vector3 DeltaDir { get { return TouchPos - LatestTouchPos; } }
        public float touchTime = 0;
        public float tappTime = 0.016f * 15;
        public float tappMinTime = 0.016f * 3;
        public bool IsTap { get { return (touchTime <= tappTime) & dist < 50 && (touchTime >= tappMinTime); } }
        public bool IsTouching{ get { return CurrentTouchState == TouchState.Touching;}}
        public float GetWorldDist()
        {
            Vector3 sP = TouchInputManager.ChangeToWorldPos(TouchStartPos);
            Vector3 cP = TouchInputManager.ChangeToWorldPos(TouchPos);

            return (cP - sP).magnitude;
        }
        public bool IsFlick(out Vector3 dir)
        {
            dir = CameraDir;
            return IsTap && GetWorldDist() > 0.2f;
        }
    }

    public enum TouchState
    {
        None,
        Down,
        Up,
        Touching
    }
}

public interface ITouchInput
{
    void TouchUp(CP.MyTouchInput.TouchInfo info);
    void TouchDown(CP.MyTouchInput.TouchInfo info);
    void Touching(CP.MyTouchInput.TouchInfo info);
}


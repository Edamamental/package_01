using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CP.Useful
{
    public class TargetLookAt : MonoBehaviour
    {
        [SerializeField] Transform m_Target; // ターゲットのTransform
        [SerializeField] float m_HorizontalRotationLimit = 180.0f; // 横方向の角度制限
        [SerializeField] float m_VerticalRotationLimit = 30.0f; // 縦方向の角度制限
        [SerializeField, Range(0, 1)] float m_RotSmooth = 0.3f;//回転のスムース
        [SerializeField, Range(0, 1)] float m_RotWeight = 1;

        public delegate void HorizontalAngleLimit(float angle);
        HorizontalAngleLimit HorizontalAngleLimitEvent;

        public delegate void VerticalAngleLimit(float angle);
        VerticalAngleLimit VerticalAngleLimitEvent;

        void FixedUpdate()
        {
            if (m_Target != null)
            {
                // ターゲットへのベクトル
                Vector3 lookDirection = (m_Target.position - transform.position).normalized;

                //極座標の角度を求める
                float horizontalAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
                float verticalAngle = Mathf.Asin(lookDirection.y / 1) * Mathf.Rad2Deg;

                if (Mathf.Abs(horizontalAngle) >= m_HorizontalRotationLimit)
                {
                    OnHorizontalAngleLimit(horizontalAngle);
                }
                if (Mathf.Abs(verticalAngle) >= m_VerticalRotationLimit)
                {
                    OnVerticalAngleLimit(verticalAngle);
                }


                //角度をリミットで制限
                horizontalAngle = Mathf.Clamp(horizontalAngle, -m_HorizontalRotationLimit, m_HorizontalRotationLimit);
                verticalAngle = Mathf.Clamp(verticalAngle, -m_VerticalRotationLimit, m_VerticalRotationLimit);

                //極座標のアングル値を元に回転に変換
                Quaternion desiredRotation = Quaternion.AngleAxis(horizontalAngle, Vector3.up) * Quaternion.AngleAxis(verticalAngle, -Vector3.right);

                //ウェイト値の反映
                desiredRotation = Quaternion.Lerp(Quaternion.identity, desiredRotation, m_RotWeight);

                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, desiredRotation, m_RotSmooth);

            }
        }

        void OnHorizontalAngleLimit(float value)
        {
            if (HorizontalAngleLimitEvent != null)
            {
                HorizontalAngleLimitEvent.Invoke(value);
            }
        }
        void OnVerticalAngleLimit(float value)
        {
            if (VerticalAngleLimitEvent != null)
            {
                VerticalAngleLimitEvent.Invoke(value);
            }
        }
    }

}


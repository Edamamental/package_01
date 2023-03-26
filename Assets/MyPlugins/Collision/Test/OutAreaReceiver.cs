using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

public class OutAreaReceiver : CollisionReceiverBase<OutAreaHitData>
{
    [SerializeField]float m_SafeTime = 5;
    float m_Timer = 0;
    OutAreaHitData m_Data = null;
    public override void EnterCol(OutAreaHitData data){}
    public override void ExitCol(OutAreaHitData data)
    {
        m_Data = null;
    }
    public override void StayCol(OutAreaHitData data)
    {
        m_Data = data;
    }

    void Update()
    {
        if(m_Data != null)
        {
            m_Timer += Time.deltaTime;
            Debug.Log(m_SafeTime-m_Timer);

        }
        else if(m_Timer != 0)
        {
            m_Timer = 0;
        }
        
    }
}

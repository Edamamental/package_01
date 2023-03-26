using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CollSystem;

public class SampleCollisionTrigger : BaseCollisionTrigger<SampleCollisiomTriggerOwmer>
{
    
    public override void OnTargetEnter(BaseCollisionReceiver<SampleCollisiomTriggerOwmer> receiver)
    {
        base.OnTargetEnter(receiver);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CollSystem;

public class SampleCollisiomTriggerOwmer : BaseCollisionTriggerOwner<SampleCollisiomTriggerOwmer>
{
    public override void OnTargetEnter(BaseCollisionReceiver<SampleCollisiomTriggerOwmer> receiver){}
    public override void OnTargetStay(BaseCollisionReceiver<SampleCollisiomTriggerOwmer> receiver){}
    public override void OnTargetExit(BaseCollisionReceiver<SampleCollisiomTriggerOwmer> receiver){}
}

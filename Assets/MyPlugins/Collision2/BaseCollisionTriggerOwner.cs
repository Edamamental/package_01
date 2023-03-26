using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CollSystem;
using MySystem;

namespace CollSystem
{
    public abstract class BaseCollisionTriggerOwner<T>:ChildOwner<T> where T : BaseCollisionTriggerOwner<T>
    {
        public abstract void OnTargetEnter(BaseCollisionReceiver<T> receiver);
        public abstract void OnTargetStay(BaseCollisionReceiver<T> receiver);
        public abstract void OnTargetExit(BaseCollisionReceiver<T> receiver);
    }
}


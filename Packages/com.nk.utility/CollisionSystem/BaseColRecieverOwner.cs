using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;

namespace CP.CollSystem
{
    public abstract class BaseColRecieverOwner<T, U> : MonoBehaviour, ICollisiomReceiverOwner<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        public abstract T Owner { get; }
        public abstract void OnTargetEnter(ICollisionTriggerOwner<U, T> target);
        public abstract void OnTargetStay(ICollisionTriggerOwner<U, T> target);
        public abstract void OnTargetExit(ICollisionTriggerOwner<U, T> target);
    }
}


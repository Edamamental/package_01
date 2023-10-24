using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;

namespace CP.CollSystem
{
    public abstract class BaseColTriggerOwner<T, U> : MonoBehaviour, ICollisionTriggerOwner<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        public abstract T Owner { get; }

        public abstract void OnSomethingEnter(Collider other);
        public abstract void OnSomethingExit(Collider other);
        public abstract void OnSomethingStay(Collider other);
        public abstract void OnTargetEnter(ICollisiomReceiverOwner<U, T> target, Collider other);
        public abstract void OnTargetExit(ICollisiomReceiverOwner<U, T> target, Collider other);
        public abstract void OnTargetStay(ICollisiomReceiverOwner<U, T> target, Collider other);
    }
}


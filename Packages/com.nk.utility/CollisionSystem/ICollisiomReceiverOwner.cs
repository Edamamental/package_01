using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;

namespace CP.CollSystem
{
    public interface ICollisiomReceiverOwner<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        T Owner { get; }
        void OnTargetEnter(ICollisionTriggerOwner<U, T> target);
        void OnTargetStay(ICollisionTriggerOwner<U, T> target);
        void OnTargetExit(ICollisionTriggerOwner<U, T> target);
    }
}




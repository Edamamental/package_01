using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;


namespace CP.CollSystem
{
    //コリジョントリガーをもつ親側の処理
    public interface ICollisionTriggerOwner<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        public T Owner { get; }
        public void OnTargetEnter(ICollisiomReceiverOwner<U, T> target,Collider other);
        public void OnTargetStay(ICollisiomReceiverOwner<U, T> target, Collider other);
        public void OnTargetExit(ICollisiomReceiverOwner<U, T> target, Collider other);
        public void OnSomethingEnter(Collider other);
        public void OnSomethingStay(Collider other);
        public void OnSomethingExit(Collider other);
    }
}


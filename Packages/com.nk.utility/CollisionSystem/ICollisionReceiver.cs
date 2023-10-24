using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;

namespace CP.CollSystem
{
    public interface ICollisionReceiver<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        public ICollisiomReceiverOwner<T, U> Owner { get; }

    }
}


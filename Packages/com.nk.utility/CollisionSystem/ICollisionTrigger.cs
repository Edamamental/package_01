using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;

namespace CP.CollSystem
{
    public interface ICollisionTrigger<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        ICollisionTriggerOwner<T, U> Owner { get; }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySystem;

namespace MySystem
{
    //IhasOwnerが子供にいる場合に自身をOWNERとする
    public abstract class ChildOwner<T> : MonoBehaviour where T : ChildOwner<T>
    {
        protected virtual void Awake()
        {
            foreach (var target in this.GetComponentsInChildren<IHasOwner<T>>())
            {
                target.SetOwner(this as T);
            }
        }
    }
}


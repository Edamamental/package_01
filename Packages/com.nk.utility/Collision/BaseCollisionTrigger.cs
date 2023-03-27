using UnityEngine;
using MySystem;
using CollSystem;

namespace CollSystem
{
    public abstract class BaseCollisionTrigger<T> : MonoBehaviour,ICollisionTrigger<T>, IHasOwner<T> where T : BaseCollisionTriggerOwner<T>
    {
        public T Owner { get; private set;}
        public void SetOwner(T owner)
        {
            Owner = owner;
        }
        public virtual void OnTargetEnter(BaseCollisionReceiver<T> receiver)
        {
            Debug.Assert(Owner!=null, "Need ChildOwner Class");
            Owner.OnTargetEnter(receiver);
        }
        public virtual void OnTargetStay(BaseCollisionReceiver<T> receiver)
        {
            Debug.Assert(Owner != null, "Need ChildOwner Class");
            Owner.OnTargetStay(receiver);
        }
        public virtual void OnTargetExit(BaseCollisionReceiver<T> receiver)
        {
            Debug.Assert(Owner != null, "Need ChildOwner Class");
            Owner.OnTargetExit(receiver);
        }
    }
}


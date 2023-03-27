using UnityEngine;

namespace CollSystem
{
    /// <Summry>
    /// コリジョン接触を受け取るクラス
    /// ICollisionTriggerのコンポーネントを持つオブジェクトとの判定をチェック
    /// 見つけたら相手に返す
    /// </Summry>
    public abstract class BaseCollisionReceiver <T> : MonoBehaviour where T : BaseCollisionTriggerOwner<T>
    {
        /// <param> 
        [SerializeField]string[] m_TargetTagName = null;
        public string[] TargetTagName{get{return m_TargetTagName;}}
        /// </param>
        public virtual void OnTriggerEnter(Collider other) 
        {
            ICollisionTrigger<T> collisionTrigger = null;
            if(GetTarget(other,out collisionTrigger))
            {
                
                if(collisionTrigger != null)
                {
                    OnTargetEnter(other,collisionTrigger);

                }
                else
                {
                    OnSomethingEnter(other);
                }
            }
        }
        public virtual void OnTriggerStay(Collider other) 
        {
            ICollisionTrigger<T> collisionTrigger = null;
            if (GetTarget(other, out collisionTrigger))
            {
                if (collisionTrigger != null)
                {
                    OnTargetStay(other, collisionTrigger);

                }
                else
                {
                    OnSomethingStay(other);
                }
            }
        }
        public virtual void OnTriggerExit(Collider other) 
        {
            ICollisionTrigger<T> collisionTrigger = null;
            if (GetTarget(other, out collisionTrigger))
            {
                if (collisionTrigger != null)
                {
                    OnTargetExit(other, collisionTrigger);

                }
                else
                {
                    OnSomethingExit(other);
                }
            }
        }
        bool GetTarget(Collider other, out  ICollisionTrigger<T> target)
        {
            target = null;
            foreach(string t_tag in m_TargetTagName)
            {
                if(t_tag == other.tag)
                {
                    target = other.GetComponent<ICollisionTrigger<T>>();
                    return true;
                }
            }
            return false;
        }
        protected virtual void OnSomethingEnter(Collider other){}
        protected virtual void OnSomethingStay(Collider other){}
        protected virtual void OnSomethingExit(Collider other){}

        protected virtual void OnTargetEnter(Collider other, ICollisionTrigger<T> collisionTrigger) 
        {
            collisionTrigger.OnTargetEnter(this);
        }
        protected virtual void OnTargetStay(Collider other, ICollisionTrigger<T> collisionTrigger) 
        {
            collisionTrigger.OnTargetStay(this);
        }
        protected virtual void OnTargetExit(Collider other, ICollisionTrigger<T> collisionTrigger) 
        {
            collisionTrigger.OnTargetExit(this);
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;

namespace CP.CollSystem
{
    //コリジョンを判定をチェックして相手側に渡すコンポーネント
    //このクラスを継承したクラスを作成し受け渡すコリジョンの階層にこのコンポーネントをつける
    //Tには自身の親、Uにはターゲットの親を指定する。
    //m_rootObj には自身の親のインターフェースをもつオブジェクトを指定する
    public abstract class BaseColTrigger<T, U> : MonoBehaviour, ICollisionTrigger<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        public ICollisionTriggerOwner<T, U> Owner { get; protected set; }
        [SerializeField] GameObject rootObj = null;
        [SerializeField] LayerMask m_TargetMask = new LayerMask();

        public virtual void Awake()
        {
            Owner = rootObj.GetComponent<ICollisionTriggerOwner<T, U>>();
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (CanHit(other, m_TargetMask))
            {
                ICollisionReceiver<U, T> target = other.GetComponent<ICollisionReceiver<U, T>>();
                if (target != null)
                {
                    //ターゲットがある場合は、相手の親、自分の親に伝える
                    Owner.OnTargetEnter(target.Owner,other);
                    target.Owner.OnTargetEnter(Owner);
                }
                else
                {
                    Owner.OnSomethingEnter(other);
                }
            }
        }

        protected void OnTriggerExit(Collider other)
        {
            if (CanHit(other, m_TargetMask))
            {
                ICollisionReceiver<U, T> target = other.GetComponent<ICollisionReceiver<U, T>>();
                if (target != null)
                {
                    //ターゲットがある場合は、相手の親、自分の親に伝える
                    Owner.OnTargetExit(target.Owner, other);
                    target.Owner.OnTargetExit(Owner);
                }
                else
                {
                    Owner.OnSomethingExit(other);
                }
            }

        }

        protected void OnTriggerStay(Collider other)
        {
            if (CanHit(other, m_TargetMask))
            {
                ICollisionReceiver<U, T> target = other.GetComponent<ICollisionReceiver<U, T>>();
                if (target != null)
                {
                    //ターゲットがある場合は、相手の親、自分の親に伝える
                    Owner.OnTargetStay(target.Owner, other);
                    target.Owner.OnTargetStay(Owner);
                }
                else
                {
                    Owner.OnSomethingStay(other);
                }
            }
        }

        //レイヤーマスクの判定
        bool CanHit(Collider other, LayerMask layerMask)
        {
            return ((1 << other.gameObject.layer) & layerMask) != 0;
        }
    }
}


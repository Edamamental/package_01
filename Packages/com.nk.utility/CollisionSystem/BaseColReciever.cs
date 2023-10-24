using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.CollSystem;

namespace CP.CollSystem
{
    //コリジョンを受け取る側のコリジョンにつけるコンポーネント
    //このクラスを継承したクラスを作成し受け取るコリジョンの階層にこのコンポーネントをつける
    //Tには自身の親、Uにはターゲットの親を指定する。
    //m_rootObj には自身の親のインターフェースをもつオブジェクトを指定する
    public abstract class BaseColReciever<T, U> : MonoBehaviour, ICollisionReceiver<T, U> where T : MonoBehaviour where U : MonoBehaviour
    {
        public ICollisiomReceiverOwner<T, U> Owner { get; protected set; }
        [SerializeField] GameObject m_rootObj = null;

        //最初に親のインターフェースを取得
        public virtual void Awake()
        {
            Owner = m_rootObj.GetComponent<ICollisiomReceiverOwner<T, U>>();
        }
    }
}


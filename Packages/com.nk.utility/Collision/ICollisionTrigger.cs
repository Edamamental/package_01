using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CollSystem;

/// <Sammary>
/// ヒットしたコリジョンとやりとりするクラスが持つインターフェース。
/// 型をジェネリックにすることで、必要なクラスとの当たりだけをとる
/// </Sammary>

namespace CollSystem
{
    public interface ICollisionTrigger<T> where T : BaseCollisionTriggerOwner<T>
    {
        T Owner{get;}
        void OnTargetEnter(BaseCollisionReceiver<T> receiver);
        void OnTargetStay(BaseCollisionReceiver<T> receiver);
        void OnTargetExit(BaseCollisionReceiver<T> receiver);
    }
}

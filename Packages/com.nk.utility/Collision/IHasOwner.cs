using UnityEngine;

namespace MySystem
{
	/// <summry>
	/// オーナーは継承先で設定が必要
	/// </summry>
    public interface IHasOwner<T> where T : ChildOwner<T>
    {
        void SetOwner(T owner);
        T Owner { get; }
    }

}


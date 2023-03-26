using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

namespace MyCollisionSystem
{
	public abstract class CollisionReceiverBase<T> : MonoBehaviour where T : HitData
	{
		//コリジョンはルートにいないのでルートのオブジェクトがわかるようにする
		public GameObject Owner { get; set; }
		public void SetOwner(GameObject owner)
		{
			Owner = owner;
		}

		private void Start() 
		{
            SetUp();
		}

		private void OnEnable() 
		{
            OnEnterCol += EnterCol;
            OnExitCol += ExitCol;
            OnStayCol += StayCol;
		}
		

		void OnDisable()
		{
            OnEnterCol -= EnterCol;
            OnExitCol -= ExitCol;
            OnStayCol -= StayCol;
		}

		protected virtual void SetUp(){}

		public delegate void EnterC(T data);
        public delegate void ExitC(T data);
        public delegate void StayC(T data);
		public EnterC OnEnterCol;
        public ExitC OnExitCol;
        public EnterC OnStayCol;

		public abstract void EnterCol(T data);
		public abstract void ExitCol(T data);
		public abstract void StayCol(T data);
	}
}


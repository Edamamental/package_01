using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollisionSystem;

//衝突判定の仕組み
namespace MyCollisionSystem
{
	//-------------------------------------------------------------------------------------------------------------
	//触れたトリガーコリジョンにreceiverがあるか確認してヒット処理を行う
	//ChaildOwnerをもつオブジェクトの子供として使う。複数のコライダー事に管理できるようにするため
	//使い方
	//トリガーコリジョンの設定されているオブジェクトに付ける
	//ターゲットになるタグを指定すうｒ
	//-------------------------------------------------------------------------------------------------------------

	public abstract class CollisionTriggerBase<T> : MonoBehaviour where T : HitData
	{
		[SerializeField]protected T hitData = null;                                               //ヒットした際に渡すデータ。渡すデータの種類に応じて必要なコリジョンだけ判定
		[SerializeField]protected string[] targetTagName = new string[] { };        //ヒット対象のタグ
		CollisionReceiverBase<T> stayCollisionReceiver = null;                            //Stayの際の処理をかるくするため一度獲得したら保持する。Exit時にリセット
		bool isValid = true;

		//==============================
		//IHasOwnerのインターフェース
		public GameObject Owner { get; set; }

		public void CollisionActivate()
		{
			isValid = true;
		}
		public void CollisionSleep()
		{
			isValid = false;
		}

		//コライダーが接した時
		protected virtual void OnTriggerEnter(Collider other)
		{
			if (!isValid)
			{
				return;
			}
			//HitDataを受け渡し可能なreceiverがあるかチェック。ReciverはCollisionReceiverBaseを継承している
			CollisionReceiverBase<T> receiver = GetReciever(other);
			if(receiver != null)
			{
				hitData.HitPos = other.ClosestPointOnBounds(this.transform.position);
				OnEnterHitObj(other, receiver);
			}
			else
			{
				OnEnterSomething(other);
			}
		}
		//コライダーが接し続けている
		protected virtual void OnTriggerStay(Collider other)
		{
			if (!isValid)
			{
				return;
			}
			//HitDataを受け渡し可能なreceiverがあるかチェック。ReciverはCollisionReceiverBaseを継承している
			//フレーム単位で難度も呼ばれるので重い処理は一かいだけOnTriggerExit でリセット
			if (stayCollisionReceiver == null)
			{ 
				stayCollisionReceiver = GetReciever(other);	
			}

			//receiverがある場合はreceiverを呼び続ける
			if(stayCollisionReceiver != null)
			{
				hitData.HitPos = other.ClosestPointOnBounds(this.transform.position);
				//receiver側にヒットを伝える
				OnStayHitObj(other, stayCollisionReceiver);
			}
			else
			{
				OnStaySomething(other);
			}
		}
		//コライダーが抜けた時
		protected virtual void OnTriggerExit(Collider other)
		{
			if (!isValid)
			{
				return;
			}
			//HitDataを受け渡し可能なreceiverがあるかチェック。ReciverはCollisionReceiverBaseを継承している
			CollisionReceiverBase<T> receiver = GetReciever(other);
			if (receiver != null)
			{
				hitData.HitPos = other.ClosestPointOnBounds(this.transform.position);
				//receiver側にヒットを伝える
				OnExitHitObj(other, receiver);
			}
			else
			{
				OnExitSomething(other);
			}
			stayCollisionReceiver = null;
		}

		//対象物がぶつかった瞬間※継承先で処理を分岐
		protected virtual void OnEnterHitObj(Collider other, CollisionReceiverBase<T> receiver)
		{
			receiver.OnEnterCol(hitData);
		}
		//対象物がぶつかっている間※継承先で処理を分岐
		protected virtual void OnStayHitObj(Collider other, CollisionReceiverBase<T> receiver)
		{
			receiver.OnStayCol(hitData);
		}
		//対象物が離れた時※継承先で処理を分岐
		protected virtual void OnExitHitObj(Collider other, CollisionReceiverBase<T> receiver)
		{
			if(receiver != null)
			{
				receiver.OnExitCol(hitData);
			}
			else
			{
				Debug.Log("Receiver is alady broken");
			}
		}

		//対象物以外に当たった場合の処理
		protected virtual void OnEnterSomething(Collider other){}
		//対象物以外に当たった場合の処理
		protected virtual void OnStaySomething(Collider other) { }
		//対象物以外に当たった場合の処理
		protected virtual void OnExitSomething(Collider other) { }

		//対象のReceiverを持っているかチェックする。持っている場合はそのReceiver。
		protected CollisionReceiverBase<T> GetReciever(Collider hitCol )
		{
			foreach(string st in targetTagName)
			{
				if (hitCol.gameObject.CompareTag(st))
				{
					return hitCol.gameObject.GetComponent<CollisionReceiverBase<T>>();
				}
			}
			return null;
		}
		
		//ターゲットのタグの変更　拾った武器のダメージを与える時などに仕様
		public virtual void OverrideTargetTag(string[] tagName)
		{
			targetTagName = tagName;
		}

		//---------------------------------------------------------------------
		//IHasOwnerのインターフェース関数。
		public virtual void SetOwner(GameObject owner)
		{
			Owner = owner;
		}

		
	}
}


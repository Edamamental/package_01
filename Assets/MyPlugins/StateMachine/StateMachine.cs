using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineSystem;


namespace StateMachineSystem
{
	[System.Serializable]
	public class StateMachine<T> where T : MonoBehaviour
	{
		T Owner;
		State<T> CurrentStete = null;
		Coroutine StateCor = null;

		public StateMachine(T owner, State<T> firstState)
		{
			Owner = owner;

			ChangeStete(firstState);
		}

		public void OnDestroy()
		{
			CurrentStete.StateExit(Owner);
		}

		public void ChangeStete(State<T> nextSteta)
		{
			
			//初回時はステート入っていないのでスキップ
			if(CurrentStete != null)
			{
				CurrentStete.StateExit(Owner);
			}
			CurrentStete = nextSteta;
			CurrentStete.StateEnter(Owner);

			//コルーチンをここで留めるて新しいステートのコルーチンを開始
			if (StateCor != null)
			{
				Owner.StopCoroutine(StateCor);
			}
			if(Owner != null)
			{
                StateCor = Owner.StartCoroutine(CurrentStete.StateUpdateEn(Owner));

			}
			
		}

		public void StateMachineUpdate()
		{
			CurrentStete.StateUpdate(Owner);
		}
		public void StateMachineFixedUpdate()
		{
			CurrentStete.StateFixeUpdate(Owner);
		}

		public State<T> GetCurrentState()
		{
			return CurrentStete;
		}
	}
}

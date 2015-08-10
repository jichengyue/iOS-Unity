using UnityEngine;
using System.Collections;

public partial class EnemyAI : StateMachine {

	public float waitingTime = 3f;

	float waitingTimer = 0f;

	void WaitingStart()
	{
		waitingTimer = 0f;
	}
	
	void WaitingUpdate()
	{
		if ( scanner.playerInSight ) {
			SetState("AIState_Chasing");
			return;
		}

		waitingTimer += Time.deltaTime;

		if(waitingTimer >= waitingTime){
			SetState("AIState_Patrolling");
		}
	}
	
}

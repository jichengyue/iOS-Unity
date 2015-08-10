using UnityEngine;
using System.Collections;

public partial class EnemyAI : StateMachine {

	int wayPointIndex = 0;

	void PatrollingStart()
	{
		wayPointIndex ++;
		if (wayPointIndex >= patrolPoints.Length)
			wayPointIndex = 0;

//		MoveTo( patrolPoints[wayPointIndex].position );
	}

	void PatrollingUpdate()
	{
		if (scanner.playerInSight) {
			SetState ("AIState_Chasing");
			return;
		}

		if (moveController.IsStopped) {
			SetState ("AIState_Waiting");
			return;
		}
	}
}

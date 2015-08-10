using UnityEngine;
using System.Collections;

public partial class EnemyAI : StateMachine {

	void ChasingStart()
	{
		MoveTo (_newTargetPosition);
	}

	void ChasingUpdate()
	{
		if (!scanner.playerInSight && moveController.IsStopped) {
			SetState ("AIState_Waiting");
			return;
		}

		if( _inShootingRange && scanner.playerInSight)
		{
			SetState("AIState_Shooting");
			return;
		}

		if (_newTargetPosition != _lastTargetPosition) {
			_lastTargetPosition = _newTargetPosition;
			MoveTo (_newTargetPosition);
			return;
		}
	}
}

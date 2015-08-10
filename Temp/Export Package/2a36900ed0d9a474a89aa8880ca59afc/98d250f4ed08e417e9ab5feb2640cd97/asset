using UnityEngine;
using System.Collections;

public partial class EnemyAI : StateMachine {

	void ShootingStart()
	{
		moveController.Stop ();
		StartCoroutine ("FreeFire");
//		_rigibody.isKinematic = false;

	}
	
	void ShootingUpdate()
	{
		if (!scanner.playerInSight) {
			SetState("AIState_Chasing");
			return;
		}

		AimAt (_newTargetPosition);
	}
	

	void ShootingExit()
	{
//		_rigibody.isKinematic = true;
		signalStopFire.SendSignals (this);
		StopCoroutine ( "FreeFire" );
	}

	void AimAt( Vector3 position )
	{
		_rigibody.transform.LookAt ( position );
	}

	IEnumerator FreeFire()
	{
		while (true) {
			yield return new WaitForSeconds( 1f );
			signalFire.SendSignals (this);
			yield return new WaitForSeconds( 0.2f );
			signalStopFire.SendSignals(this);
		}
	}
}

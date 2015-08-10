using UnityEngine;
using System.Collections;

public partial class EnemyAI : StateMachine {
	
	public MoveController moveController;
	public Scanner  scanner;
	public Rigidbody _rigibody;
	public SignalSender signalFire;
	public SignalSender signalStopFire;
	public Transform[] patrolPoints;

	private GameObject player;	
	private Vector3 _lastTargetPosition;
	private Vector3 _newTargetPosition;
	private bool _inShootingRange = false;
	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");


		AddState ("AIState_Patrolling", PatrollingUpdate, PatrollingStart);
		AddState ("AIState_Chasing", ChasingUpdate, ChasingStart);
		AddState ("AIState_Shooting", ShootingUpdate, ShootingStart, ShootingExit);
		AddState ("AIState_Waiting", WaitingUpdate, WaitingStart);
		SetState ("AIState_Patrolling");
	}
	
	public void MoveTo(Vector3 targetPosition)
	{
		moveController.MoveTo (targetPosition);
	}

	public void GetTarget( Vector3 targetPosition )
	{
		targetPosition.y = 0f;
		_newTargetPosition = targetPosition;
	}

	public void LoseTarget()
	{
	}

	void OnEnable()
	{
		if( !IsEmpty )
		 SetState ("AIState_Patrolling");
	}

	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject == player)
		{
			_inShootingRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player)
		{
			_inShootingRange = false;
		}
	}
}

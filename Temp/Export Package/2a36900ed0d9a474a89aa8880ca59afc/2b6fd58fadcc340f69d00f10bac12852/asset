using UnityEngine;
using System.Collections;

public class Scanner : MonoBehaviour {

	public float fieldOfViewAngle = 110f;	
		
	public struct x{
		int s;
	}

	public x i;
	public SignalSender playerInsightSignal = new SignalSender();
	public SignalSender playerOutsightSignal = new SignalSender();

	[HideInInspector]
	public bool playerInSight;

	private SphereCollider col;	
	private GameObject player;		
	private Vector3 lastPlayerPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		col = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject == player)
		{

			if( DetectPlayer() )
				playerInsightSignal.SendSignals(this, lastPlayerPosition);
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if (other.gameObject == player)
		{
			// ... the player is not in sight.
			if( !DetectPlayer() )
			{
				playerInSight = false;
				playerOutsightSignal.SendSignals( this );
			}
		}
	}

	bool DetectPlayer(){

		// By default the player is not in sight.
		playerInSight = false;
		
		// Create a vector from the enemy to the player and store the angle between it and forward.
		Vector3 direction = player.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.forward);
		
		// If the angle between forward and where the player is, is less than half the angle of view...
		if(angle < fieldOfViewAngle * 0.5f)
		{
			RaycastHit hit;
			
			// ... and if a raycast towards the player hits something...
			if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
			{
				// ... and if the raycast hits the player...
				if(hit.collider.gameObject == player)
				{
					// ... the player is in sight.
					playerInSight = true;
					
					// Set the last global sighting is the players current position.
					lastPlayerPosition = player.transform.position;
				}
			}
		}
		return playerInSight;
	}

	void OnEnable()
	{
		playerInSight = false;
	}
}

using UnityEngine;
using System.Collections;

public class MovementMotor : MonoBehaviour {

	[HideInInspector]
	public Vector3 movementDirection ;
	
	// Simpler motors might want to drive movement based on a target purely
	[HideInInspector]
	public Vector3 movementTarget ;
	
	// The direction the character wants to face towards, in world space.
	[HideInInspector]
	public Vector3 facingDirection ;

	public float walkingSpeed  = 5.0f;
	public float walkingSnappyness = 50f;
	public float turningSmoothing  = 0.3f;
	
	void FixedUpdate () {
		// Handle the movement of the character
		Vector3 targetVelocity = movementDirection * walkingSpeed;
		Vector3 deltaVelocity  = targetVelocity - GetComponent<Rigidbody>().velocity;
		if (GetComponent<Rigidbody>().useGravity)
			deltaVelocity.y = 0;
		GetComponent<Rigidbody>().AddForce (deltaVelocity * walkingSnappyness, ForceMode.Acceleration);

//		UpdateRotation ();

	}

	void UpdateRotation()
	{
		// Setup player to face facingDirection, or if that is zero, then the movementDirection
		Vector3 faceDir = facingDirection;
		if (faceDir == Vector3.zero)
			faceDir = movementDirection;
		
		// Make the character rotate towards the target rotation
		if (faceDir == Vector3.zero) {
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
		else {
			float rotationAngle = AngleAroundAxis (transform.forward, faceDir, Vector3.up);
			GetComponent<Rigidbody>().angularVelocity = (Vector3.up * rotationAngle * turningSmoothing);
		}
	}
	
	// The angle between dirA and dirB around axis
	static float AngleAroundAxis ( Vector3 dirA  , Vector3 dirB , Vector3 axis ) {
		// Project A and B onto the plane orthogonal target axis
		dirA = dirA - Vector3.Project (dirA, axis);
		dirB = dirB - Vector3.Project (dirB, axis);
		
		// Find (positive) angle between A and B
		float angle = Vector3.Angle (dirA, dirB);
		
		// Return angle multiplied with 1 or -1
		return angle * (Vector3.Dot (axis, Vector3.Cross (dirA, dirB)) < 0 ? -1 : 1);
	}

}

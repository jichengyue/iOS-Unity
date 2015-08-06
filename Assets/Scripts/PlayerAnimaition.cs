using UnityEngine;
using System.Collections;

public class PlayerAnimaition : MonoBehaviour {

	public Animator animator;
	private Transform tr;
	private Vector3 localVelocity;
	private float speed;
	private float angle;
	private Vector3 lastPosition;
	// Use this for initialization
	void Start () {

		tr = transform;
		lastPosition = tr.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 velocity = GetComponent<Rigidbody> ().velocity;//(tr.position - lastPosition) / Time.deltaTime;
		localVelocity = tr.InverseTransformDirection (velocity);
		localVelocity.y = 0;
		speed = localVelocity.magnitude;
		angle = ( HorizontalAngle (localVelocity) + 360f )%360f;
		
		lastPosition = tr.position;

		animator.SetFloat ("Speed", speed);
		animator.SetFloat ("Angle", angle);

//		Debug.Log ("Speed: " + speed + " Angle: " + angle);

	}

	void FixedUpdate () {

	}

	static float HorizontalAngle (Vector3 direction) {
		return Mathf.Atan2 (direction.z, direction.x) * Mathf.Rad2Deg;
	}

}

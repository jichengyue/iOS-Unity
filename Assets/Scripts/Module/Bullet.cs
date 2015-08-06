using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed = 10f;
	public float lifeTime  = 0.5f;
	public float dist = 10000;
	
	private float spawnTime  = 0.0f;
	private Transform tr ;
//	private Health _health;

	void OnEnable () {
		tr = transform;
		spawnTime = Time.time;
	}
	
	void Update () {
		tr.position += tr.forward * speed * Time.deltaTime;
		dist -= speed * Time.deltaTime;
		if (Time.time > spawnTime + lifeTime || dist < 0) {
	//		Destroy (gameObject);
			Spawner.Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		Debug.Log ("collision with: " + other.gameObject.name);
	//	if (other.tag != "AI_Trigger" && other.tag != "Damage_Trigger") 
		{
			Spawner.Destroy (gameObject);

//			_health = other.GetComponent<Health>();
//			if( _health != null )
//				_health.OnDamage();
		}
	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log ( "collider stay" );
	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ( "collider exit" );
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("collision with: " + collision.gameObject.name);
		Spawner.Destroy (gameObject);
	}

	void OnCollisionStay(Collision other) 
	{
		Debug.Log ( "collision stay" );
	}

	void OnCollisionExit(Collision other) 
	{
		Debug.Log ( "collision exit" );
	}
}

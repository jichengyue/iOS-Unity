using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth = 100;
	public int health = 100;
	public SignalSender damageSignals;
	public SignalSender deathSignals;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDamage( int damage = 1 )
	{
		health --;
		damageSignals.SendSignals(this, this);

		if (health == 0)
			deathSignals.SendSignals (this, gameObject);
	}

	void OnEnable()
	{
		health = maxHealth;
	}
}

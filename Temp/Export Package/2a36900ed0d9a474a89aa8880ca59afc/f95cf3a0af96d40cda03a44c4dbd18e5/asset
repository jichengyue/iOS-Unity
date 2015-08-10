using UnityEngine;
using System.Collections;

public class TriggerOnMouse : MonoBehaviour {
	public SignalSender mouseDownSignals ;
	public SignalSender mouseUpSignals ;
	public GameObject target;
	void Update () {
		if (Input.GetMouseButtonDown (0))
			target.SendMessage ("OnStartFire");
		
		if (Input.GetMouseButtonUp(0))
			target.SendMessage ("OnStopFire");
	}
}

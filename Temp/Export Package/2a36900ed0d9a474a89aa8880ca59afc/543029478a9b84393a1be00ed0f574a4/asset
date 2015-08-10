using UnityEngine;
using System.Collections;

[System.Serializable]
public class ReceiverItem {
	public GameObject receiver = null;
	public string  action = "OnSignal";
	public float delay = 0f ;
	
	public IEnumerator SendWithDelay (MonoBehaviour sender, object value) {
		yield return new WaitForSeconds (delay);
		if (receiver)
			receiver.SendMessage (action, value);
		else
			Debug.LogWarning ("No receiver of signal \""+action+"\" on object "+sender.name+" ("+sender.GetType().Name+")", sender);
	}
}

[System.Serializable]
public class SignalSender {
	public bool onlyOnce = false;
	public ReceiverItem[] receivers ;
	
	private bool hasFired  = false;
	
	public void SendSignals (MonoBehaviour sender, object value = null) {
		if (hasFired == false || onlyOnce == false) {
			for (var i = 0; i < receivers.Length; i++) {
				sender.StartCoroutine (receivers[i].SendWithDelay(sender, value));
			}
			hasFired = true;
		}
	}
}
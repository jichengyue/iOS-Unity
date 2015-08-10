using UnityEngine;
using System.Collections;

public class MainLight : MonoBehaviour {

	private Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();

	}
	
	// Update is called once per frame
	void Update () {


	}

	public IEnumerator Flash()
	{
		Color color = light.color;
		while (color.b > 0.2) {
			color.b -= 0.01f;
			light.color = color;
			yield return null;
		}
		while (color.b < 0.8) {
			color.b += 0.01f;
			light.color = color;
			yield return null;
		}
	}
}

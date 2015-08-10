using UnityEngine;
using System.Collections;

public class UITest : MonoBehaviour {

	// Use this for initialization
	public GameObject playerPrefab;
	public MainLight light;
	private GameObject player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (player == null) {
			if (GUI.Button (new Rect (0, 0, 200, 200), "Creat player")) 
			{
				player = Instantiate(playerPrefab) as GameObject;
			}
						
		}
		else {
			if(GUI.Button (new Rect (0, 250, 200, 200), "Destroy player"))
				Destroy(player);
		}

		if (GUI.Button (new Rect (0, 500, 200, 200), "flash")) {
			light.StartCoroutine("Flash");
		}

	}
}

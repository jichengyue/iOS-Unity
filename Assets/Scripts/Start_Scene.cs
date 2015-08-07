using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Start_Scene : MonoBehaviour {


	public Texture bg;
	private float screen_width;
	private float screen_height;
	//public GUISkin skin_main;
	public GUIStyle label;


	void Start () {
		//skin_main.label.fontSize = (int)(Screen.width*0.05);
		
		screen_width = Screen.width;
		screen_height = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		MousePick ();
		MobilePick ();
	}

	void OnGUI() {
		GUILayout.Label ("浙江省博物馆文物展", label);
		//GUI.Label (new Rect(200,200,800,100),"浙江省博物馆文物展示");
		GUI.DrawTexture (new Rect(0,0,screen_width,screen_height),bg);
		//BeginUIResizing ();
		//GUI.skin = skin_main;
		//EndUIResizing ();
	}

	void MobilePick()
	{
		if (Input.touchCount != 1 )
			return;
		
		if (Input.GetTouch(0).phase == TouchPhase.Began)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			
			if (Physics.Raycast(ray, out hit))
			{
				//Debug.Log(hit.transform.name);
				//Debug.Log(hit.transform.tag);
				Application.LoadLevel(int.Parse(hit.transform.name));
			}
		}
	}
	
	void MousePick()
	{
		if(Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit))
			{
				//Debug.Log(hit.transform.name);
				//Debug.Log(hit.transform.tag);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class Move_buttom_FPC : MonoBehaviour {

	private GameObject objCube;
//	private float Value_X = 0.0f;
//	private float Value_Y = 0.0f;
//	private float Value_Z = 0.0f;
	private int speed = 10;

	// Use this for initialization
	void Start () {
		objCube = GameObject.Find ("First Person Controller");
	}

	void OnGUI() {

//		while (GUILayout.RepeatButton(new Rect(15, 100, 100, 50), "Backward") ){
//			transform.position += new Vector3(0, 0, -0.5f);
//		}

		if(GUILayout.RepeatButton("Up",GUILayout.Height(50)))
		{
			objCube.transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		
		if(GUILayout.RepeatButton("Down",GUILayout.Height(50)))
		{
			objCube.transform.Translate(Vector3.back * Time.deltaTime * speed);
		}
		
		if(GUILayout.RepeatButton("Right",GUILayout.Height(50)))
		{
			objCube.transform.Translate(Vector3.right * Time.deltaTime * speed);
		}

		if(GUILayout.RepeatButton("Left",GUILayout.Height(50)))
		{
			objCube.transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		
	
//		GUILayout.Label("立方体旋转角度"+objCube.transform.rotation);
	}

	// Update is called once per frame
	void Update () {
	
	}
}

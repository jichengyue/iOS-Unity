using UnityEngine;
using System.Collections;

public class touch_rotate_ZJU : MonoBehaviour {

	GameObject house;
	GameObject cube;

	float touchDeltaX = 0;
	float touchDeltaY = 0;

	// Use this for initialization
	void Start () {
		house = GameObject.Find ("house");
		cube = GameObject.Find ("house/cube");	
	}
	
	// Update is called once per frame
	void Update () {

//		if (cube != null) {
////			house.transform.RotateAround (cube.transform.position, Vector3.up, Time.deltaTime * 50);
//			house.transform.RotateAround(cube.transform.position, Vector3.up, 20);
//		} else {
//			Debug.Log("Not find Cube");
//		}



		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				//获取手指自最后一帧的移动
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				
				touchDeltaX += touchDeltaPosition.x;
				touchDeltaY += touchDeltaPosition.y;
				
				//				Debug.Log("dx :" + touchDeltaPosition.x + "dy:" + touchDeltaPosition.y);
				
				int delyXParameter = 5;
				int delyYParameter = 10;
				
				if(touchDeltaX > delyXParameter){ // 向右滑动
					
					touchDeltaX = 0;
					
					// 物体向左转
//					house.transform.Rotate(0, -2, 0);
					house.transform.RotateAround(cube.transform.position, Vector3.up, -2);

				}else if(touchDeltaX < -delyXParameter){
					
					touchDeltaX = 0;
					
					// 物体向右转
//					house.transform.Rotate(0, 2, 0);
					house.transform.RotateAround(cube.transform.position, Vector3.up, 2);
				}
				
				if(touchDeltaY > delyYParameter){ // 向上滑动
					
					touchDeltaY = 0;
					
					// 物体向上
//					house.transform.Rotate(0, 0, 2);
					house.transform.RotateAround(cube.transform.position, Vector3.right, 2);

				}else if(touchDeltaY < -delyYParameter){
					
					touchDeltaY = 0;
					
//					house.transform.Rotate(0, 0, -2);
					house.transform.RotateAround(cube.transform.position, Vector3.right, -2);
				}
			}        
		}
	}


	void OnGUI(){

		if (GUI.Button (new Rect (0 , 0 , Screen.width/8 , Screen.height/8), "Return")) {
			Application.LoadLevel("Start_Scene");
		}
	}
}

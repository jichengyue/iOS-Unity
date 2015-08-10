using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
//
//	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
//	public RotationAxes axes = RotationAxes.MouseXAndY;
//	public float sensitivityX = 15F;
//	public float sensitivityY = 15F;
//
//	public float minimumX = -360F;
//	public float maximumX = 360F;
//
//	public float minimumY = -60F;
//	public float maximumY = 60F;
//
//	float rotationY = 0F;

	float touchDeltaX = 0;
	float touchDeltaY = 0;
	float touchDeltaTime = 0;

	string stack = "";
	Ray ray;
	RaycastHit hit;
	bool touched = false;

	void Update ()
	{
		if (Input.touchCount == 1)
		{
			if(Input.GetTouch(0).phase == TouchPhase.Began){

//				Debug.Log("Touch Begin");
				stack += "1";

				ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);	
			}

			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				stack += "2";

//				Debug.Log("Touch Move");

				//获取手指自最后一帧的移动
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				
				touchDeltaX += touchDeltaPosition.x;
				touchDeltaY += touchDeltaPosition.y;
				touchDeltaTime += Time.deltaTime;

				Debug.Log("touchDeltaTime : " + touchDeltaTime);

//				Debug.Log("touchDeltaPosition.x :" + touchDeltaPosition.x + "touchDeltaPosition.y:" + touchDeltaPosition.y);
//				Debug.Log("deltax :" + touchDeltaX + "deltay:" + touchDeltaY);
				
				int delyXParameter = 20;
				int delyYParameter = 50;

				int moveX = 2;
				float moveY = 0.5f;



				if(touchDeltaX > delyXParameter){ // 向右滑动
					
					touchDeltaX = 0;
					touchDeltaY = 0;
					
					transform.Rotate(0, moveX, 0);
				}else if(touchDeltaX < -delyXParameter){
					
					touchDeltaX = 0;
					touchDeltaY = 0;
					
					transform.Rotate(0, -moveX, 0);
				}
				
				if(touchDeltaY > delyYParameter){ // 向上滑动

					touchDeltaX = 0;
					touchDeltaY = 0;
					
					transform.Translate(0, 0, moveY);
				}else if(touchDeltaY < -delyYParameter){

					touchDeltaX = 0;
					touchDeltaY = 0;
					
					transform.Translate(0, 0, -moveY);
				}
			}

			if (Input.GetTouch(0).phase == TouchPhase.Ended){

				Debug.Log("Touch Ended");
				stack += "3";
			}
		}

		if (stack.Contains ("3") == false) {
			return;
		} else {

			if (stack.Contains ("2")) {
//				Debug.Log ("Has Move");
			} else {
				touched = true;
			}
		}



		if (Physics.Raycast (ray, out hit)) {
			
			int tag;
			
			if(int.TryParse(hit.transform.tag, out tag) == true && touched == true){

				Debug.Log(stack);

				tag = int.Parse(hit.transform.tag);
				Application.LoadLevel("Pic1");
			}
			
		}else{
//			Debug.Log("Not Hit");
		}

		stack = "";;
		touched = false;

		Debug.Log ("Func Finish");

	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
}
using UnityEngine;
using System.Collections;

public class touch_change_scene_ZJU : MonoBehaviour {

//	public Object bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount == 1)
		{
			if(Input.GetTouch(0).phase == TouchPhase.Began){

				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);

				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
					// Create a particle if hit
					//如果击中，创建一个粒子
//					Debug.Log("Hit : " + hit.transform.name);

					int tag;

//					if(hit.transform.tag == "Collider"){
//						Application.LoadLevel(1);
//					}

					if(int.TryParse(hit.transform.tag, out tag) == true){
						tag = int.Parse(hit.transform.tag);
						Application.LoadLevel(tag);
					}

				}else{
					Debug.Log("Not Hit");
				}
			}
		}
	}
}

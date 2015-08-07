using UnityEngine;
using System.Collections;

public class img_scan : MonoBehaviour {
	
	public GameObject _plane; //挂一个用来显示图片的plane
	public Texture2D[] _txtAll; //挂载图片
	
	private float screen_width;
	private float screen_height;
	
	private int _index = 0;
	private int timestamp = 21;
	
	//滑动切换图片
	private Vector2 touchFirst = Vector2.zero;
	private Vector2 touchSecond = Vector2.zero;
	
	private string[] des = {"1","2","3","4","5","6"};
	
	// Use this for initialization
	void Start () {
		
		screen_width = Screen.width;
		screen_height = Screen.height;
		
		if (_txtAll.Length == 0) {
			
			var textures = Resources.LoadAll("imgscan");
			int count = textures.Length;
			_txtAll = new Texture2D[count];
			for(int i=0; i<count; i++)
			{
				_txtAll[i] = textures[i] as Texture2D;
			}
		}
		
		_plane.GetComponent<Renderer>().material.mainTexture = _txtAll [0];
	}
	
	// Update is called once per frame
	void Update () {
		
		//回到主菜单
		if (Input.GetKey(KeyCode.Escape)) {
			
			Application.LoadLevel("Start_Scene");
		}
		
		timestamp++;
		//移动
		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved && timestamp>20) {
			timestamp = 0;
			//右移
			if (Input.GetTouch (0).deltaPosition.x < 0 - Mathf.Epsilon) {
				_index = _index == _txtAll.Length - 1 ? -1 : _index;
				_index++;
			}
			else {//左移
				_index = _index == 0 ? _txtAll.Length : _index;
				_index--;
			}
			
		}
		
	}
	
	void OnGUI(){
		

		
		int width = _txtAll[_index].width;
		int height = _txtAll [_index].height;
		float scale;
		scale = Mathf.Min (screen_width/width,screen_height/height);
		GUI.DrawTexture (new Rect((screen_width-width*scale)*0.5f,(screen_height-height*scale)*0.5f,width*scale,height*scale),_txtAll[_index]);
		GUI.Label (new Rect(10,(100.0f/800.0f)*screen_height,screen_width,100),des[_index]);
		//GUILayout.Label (des [_index]);
		if (GUI.Button (new Rect (0 , 0 , (200.0f/1280.0f)*screen_width , (50.0f/800.0f)*screen_height), "Return")) {
			Application.LoadLevel("Start_Scene");
		}
	}
	
}




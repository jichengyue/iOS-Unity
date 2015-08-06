using UnityEngine;
using System.Collections;

public class Image3DViewer : MonoBehaviour {

	Texture2D image;

	int xIndex = 0;
	int yIndex = 0;

	float touchDeltaX = 0;
	float touchDeltaY = 0;

	// 四个group代表四个不同的仰角下拍摄的照片
	int groupCount = 4;
	
	// 23张picture是在同一个仰角下,左右不同角度拍摄的照片
	int pictureCount = 23;

	// Use this for initialization
	void Start () {
//		image = (Texture2D)Resources.Load("test");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				//获取手指自最后一帧的移动
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

				touchDeltaX += touchDeltaPosition.x;
				touchDeltaY += touchDeltaPosition.y;

//				Debug.Log("dx :" + touchDeltaPosition.x + "dy:" + touchDeltaPosition.y);

				int delyXParameter = 10;
				int delyYParameter = 20;

//				 更新 xindex 和 yindex
				if(touchDeltaX > delyXParameter){ // 向右滑动

					touchDeltaX = 0;

					// 物体向左转
					if (xIndex>0){
						xIndex--;
					}else{
						xIndex=pictureCount;
					}
				}else if(touchDeltaX < -delyXParameter){

					touchDeltaX = 0;

					// 物体向右转
					if (xIndex<pictureCount){
						xIndex++;
					}else{
						xIndex=0;
					}
				}

				if(touchDeltaY > delyYParameter){ // 向上滑动

					touchDeltaY = 0;
					
					// 物体向上
					if (yIndex<groupCount){
						yIndex++;
					}
				}else if(touchDeltaY < -delyYParameter){

					touchDeltaY = 0;

					if (yIndex>0){
						yIndex--;
					}
				}

//				Debug.Log("xIndex :" + xIndex + "yIndex:" + yIndex);

//				xIndex += (int)touchDeltaPosition.x;
//				yIndex += (int)touchDeltaPosition.y;




//				transform.Rotate(0, touchDeltaPosition.x, 0);
			}        
		}
	}

	void OnGUI(){

//		根据xindex 和 yindex 得到图片的文件名
		string imageName = "img_0_" + yIndex + "_" + xIndex + "[1]";
		image = (Texture2D)Resources.Load (imageName);

		if(!image){
			//如果不指定图片会输出这条消息
			Debug.Log("xIndex:" + xIndex + "yIndex:" + yIndex + " 请指定一个纹理图片");
			return;
		}
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image, ScaleMode.StretchToFill, true, 0);	
	}
}

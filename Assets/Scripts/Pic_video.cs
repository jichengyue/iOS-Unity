using UnityEngine;
using System.Collections;

public class Pic_video : MonoBehaviour {

	//电影纹理
	public MovieTexture movTexture;
	
	void Start()
	{
		//设置当前对象的主纹理为电影纹理
		GetComponent<Renderer>().material.mainTexture = movTexture;
		//设置电影纹理播放模式为循环
		movTexture.loop = true;
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width-400,Screen.height-50,100,30),"播放/继续"))
		{
			//播放/继续播放视频
			if(!movTexture.isPlaying)
			{
				movTexture.Play();
			}
			
		}
		
		//if(GUILayout.Button("暂停播放"))
		if(GUI.Button(new Rect(Screen.width-300,Screen.height-50,100,30),"暂停播放"))
		{
			//暂停播放
			movTexture.Pause();
		}


		//if(GUILayout.Button("停止播放"))
		if(GUI.Button(new Rect(Screen.width-200,Screen.height-50,100,30),"停止播放"))
		{
			//停止播放
			movTexture.Stop();
		}
	}
}

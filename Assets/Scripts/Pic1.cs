using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;  
using System;

public class Pic1 : MonoBehaviour {
	String Pic_file="pic_file1.txt";
	String Article="";
	private bool showMsg = false;
	private float screen_width;
	private float screen_height;
	public GUIContent gc;
	// Use this for initialization
	void Start () {
		screen_width = Screen.width;
		screen_height = Screen.height;
		//读取文件
		ArrayList info = LoadFile(Application.dataPath+"/Resources/Files",Pic_file);

		foreach(string str in info)  
		{  
			Article+=str;
		} 
		gc.text = Article;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{
		if (GUILayout.Button ("Return", GUILayout.Height (50), GUILayout.Width (50))) {
			Application.LoadLevel ("Start_Scene");
		}

		if (GUI.Button (new Rect ((1000.0f / 1280.0f) * screen_width, (10.0f / 800.0f) * screen_height, (200.0f / 1280.0f) * screen_width, (50.0f / 800.0f) * screen_height), "文字信息"))
			showMsg = !showMsg;
		if (showMsg) {
			//GUI.Label (new Rect (0, 150, (1000.0f / 1280.0f) * screen_width, screen_height), Article);

			GUI.Label (new Rect (0, 150, (1000.0f / 1280.0f) * screen_width, screen_height), gc);
		}
	}

	ArrayList LoadFile(string path,string name)   
	{   
		//使用流的形式读取
		StreamReader sr =null;
		try{
			sr = File.OpenText(path+"//"+ name);  
		}catch(Exception e)
		{
			//路径与名称未找到文件则直接返回空
			return null;
		}
		string line;
		ArrayList arrlist = new ArrayList();
		while ((line = sr.ReadLine()) != null)
		{
			//一行一行的读取
			//将每一行的内容存入数组链表容器中
			arrlist.Add(line);
		}
		//关闭流
		sr.Close(); 
		//销毁流
		sr.Dispose();
		//将数组链表容器返回
		return arrlist;
	}   
}

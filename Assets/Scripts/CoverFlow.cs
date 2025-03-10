﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoverFlow : MonoBehaviour
{
	private List<GameObject> photos = new List<GameObject> ();
	private int photosCount =11;
	
	private int currentIndex=0;
	private float MARGIN_X=3f;  //plane 之间的间隔
	private float ITEM_W=10f;   //plane长宽为10M（10个单位长度）
	
	private float sliderValue=0f;
	private int timestamp = 21;
	private int _index = 0;

	
	void Start ()
	{
		loadImages ();
			//moveSlider (6);
		moveSlider(0);
	}
	
	void loadImages ()
	{
		for (int i=0; i<photosCount; i++) {
			GameObject photo = GameObject.CreatePrimitive (PrimitiveType.Plane);
			photo.name=i.ToString();
			if(!photo.GetComponent<Collider>())
				photo.AddComponent<Collider>();
			photos.Add (photo);
			//photo.renderer.material.shader=Shader.Find("Self-Illumin/Diffuse");
			
			photo.transform.eulerAngles = new Vector3 (-90f,0f, 0f);
			photo.transform.localScale=new Vector3(-1.5f,1f,-1f);   //根据图片设定长宽比，z：－1，使图正向
			photo.GetComponent<Renderer>().material.mainTexture = Resources.Load ("s_scene/photo" + i.ToString(),typeof(Texture2D)) as Texture2D;
			
			
			photo.transform.parent=gameObject.transform;
		}
		
		moveSlider(photos.Count/2);
		//moveSlider(0);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (Input.touchCount != 1 )
			return;
		if(Input.GetTouch (0).phase == TouchPhase.Moved)
		{
			//timestamp = 0;
			if (Input.GetTouch (0).deltaPosition.x < 0 - Mathf.Epsilon) {
				//_index = _index == photosCount ? _index : _index;
				_index++;
				if (_index>10)
					_index=10;
			}
			else {//左移
				//_index = _index == 0 ? 1 : 1;
				_index--;
				if (_index<=0)
					_index=0;
			}
			moveSlider(_index);
			sliderValue=_index;
		}

		if(Input.GetTouch (0).phase == TouchPhase.Began)
			if (Input.GetTouch (0).phase == TouchPhase.Ended)
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
	
	void moveSlider(int id){
		if(currentIndex==id)
			return;
		currentIndex=id;
		
		for(int i=0;i<photosCount;i++){
			float targetX=0f;
			float targetZ=0f;
			float targetRot=0f;
			
			targetX=MARGIN_X*(i-id);
			//left slides
			if(i<id){
				targetX-=ITEM_W*0.6f;
				targetZ=ITEM_W*3f/4;
				targetRot=-60f;
				
			}
			//right slides
			else if(i>id){
				targetX+=ITEM_W*0.6f;
				targetZ=ITEM_W*3f/4;
				targetRot=60f;
			}else{
				targetX += 0f;
				targetZ = 0f;
				targetRot = 0f;
			}
			
			GameObject photo=photos[i];

			
			float ys=photo.transform.position.y;
			Vector3 ea=photo.transform.eulerAngles;
			
		
			
			iTween.MoveTo(photo,new Vector3(targetX,ys,targetZ),1f);
			iTween.RotateTo(photo,new Vector3(ea.x,targetRot,targetZ),1f);
		}
	}
	
	
	void OnGUI ()
	{

	}

	
}
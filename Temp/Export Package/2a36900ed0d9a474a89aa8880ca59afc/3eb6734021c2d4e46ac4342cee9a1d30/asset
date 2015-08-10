using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SceneCamera : MonoBehaviour {

	ClickListener _clickListener;
//	DragListener _dragListener;
//	PinchListener _pinchListener;
	
	public GameObject player;
	public float rotateSpeed = 0f;
	public float walkSpeed = 0f;

	private static bool globalDragAble = true;

	private Vector3 screenMovementForward ;
	private Vector3 screenMovementRight;

	public void SetGlobalDragAble(bool drag){
		globalDragAble = drag;
	}

	private bool dragAble = true;
	public void SetDragAble(bool drag){
		dragAble = drag;
	}

	void Start () 
	{
		_clickListener = new ClickListener(ClickOn);

	}
	
	void Update () {

	//	_clickListener.Update();

		if (Input.GetMouseButtonUp (0)) {

			ClickOn( Input.mousePosition );
		}

	}
	
	void ClickOn(Vector2 pos)
	{
		if (player == null)
			return;
		Ray ray = this.GetComponent<Camera>().ScreenPointToRay(pos);
		RaycastHit[] hits = Physics.RaycastAll(ray);

	
		foreach (RaycastHit hit in hits){
			BoxCollider bc = hit.collider as BoxCollider;
			if (bc != null && bc.name.Contains("floor") && player != null){
		//		player.GetComponent<Player>().WalkTo(hit.point);
				break;
			}
		}
	}

	
	void LateUpdate()
	{
//		if(player != null)
//			camera.transform.LookAt (player.transform.position);
	}

	void DragBegin(Vector2 pos)
	{}
	
	void DragTo(Vector2 begin, Vector2 lastpos, Vector2 pos)
	{
		Vector3 delta = pos - lastpos;
		delta.z = 0;
		
		if (delta.magnitude > 0.5f)
		{
			Vector3 lp = transform.localPosition;
			delta /= 100f;
			
			Vector3 nlp = lp - new Vector3(delta.x, delta.z);
			transform.localPosition = ClamePosition(nlp);
		}

	}
	
	void DragEnd(Vector2 begin, Vector2 pos)
	{}

	void Pinch(float delta)
	{
		Vector3 lp = transform.localPosition;
		Vector3 nlp = lp;
		nlp.z += delta/100f*5;
		transform.localPosition = ClamePosition(nlp);
	}

	Vector3 ClamePosition(Vector3 position){
		float minFrontX = 12;
		float maxFrontX = 22;
		float minZ = 0;
		float maxZ = 14;
		
		float minBackX = 16;
		float maxBackX = 18;

		float dstZ = Mathf.Clamp(position.z, minZ, maxZ);
		float zRate = (dstZ - minZ) / (maxZ - minZ);
		float minX = minBackX + (minFrontX - minBackX) * zRate;
		float maxX = maxBackX + (maxFrontX - maxBackX) * zRate;

		float dstX = Mathf.Clamp(position.x, minX, maxX);

		Vector3 re = position;
		re.x = dstX;
		re.z = dstZ;
		return re;
	}
}



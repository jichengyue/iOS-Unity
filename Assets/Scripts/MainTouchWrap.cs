using UnityEngine;
using System.Collections;

public class MainTouchWrap 
{
	public int touchCount;
	public Vector2 position;
	public Vector2 deltaPosition;
	public TouchPhase phase;
	
	public void Update()
	{
#if UNITY_EDITOR
		UpdateOnDesktop();
#else
		UpdateOnDevice();
#endif
	}

	void UpdateOnDevice()
	{
		touchCount = Input.touchCount;
		if (touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			position = touch.position;
			deltaPosition = touch.deltaPosition;
			phase = touch.phase;
		}
	}

	private Vector2 _lastPosition;
	void UpdateOnDesktop()
	{
		touchCount = 0;
		position = Input.mousePosition;

		if (Input.GetMouseButton(0))
		{
			touchCount = 1;
			phase = TouchPhase.Began;
			_lastPosition = position;
			deltaPosition = Vector2.zero;
			return;
		}

		if (Input.GetMouseButton(0))
		{
			touchCount = 1;
			phase = TouchPhase.Ended;
			deltaPosition = position - _lastPosition;
			return;
		}

		if (Input.GetMouseButton(0))
		{
			touchCount = 1;
		}

		deltaPosition = position - _lastPosition;
		phase = deltaPosition == Vector2.zero ? TouchPhase.Stationary : TouchPhase.Moved;
		_lastPosition = position;
	}
}

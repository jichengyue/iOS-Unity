using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ClickListener
{
	const float MAX_CLICK_LEN = 10f;
	const float MAX_CLICK_DUR = 0.2f;
	
	Vector2 _originTouchPos;
	float   _originTouchTime;
	bool 	_clickValid;
	Action<Vector2> _clickHander;
	
	MainTouchWrap _touchWrap;
		
	public ClickListener(Action<Vector2> clickHander)
	{
		_touchWrap = new MainTouchWrap();
		_clickHander = clickHander;
	}

	public void Dispose(){
		_clickValid = false;
	}
	
	public void Update()
	{
		if (_clickValid && (Time.time - _originTouchTime) > MAX_CLICK_DUR)
		{
			_clickValid = false;
		}
		
		_touchWrap.Update();
		
		if (_touchWrap.touchCount == 1)
		{
			if (_touchWrap.phase == TouchPhase.Began)
			{
				_clickValid = true;
				_originTouchPos = _touchWrap.position;
				_originTouchTime = Time.time;
			}
			else
			{
				if (_clickValid && (_touchWrap.position - _originTouchPos).magnitude > MAX_CLICK_LEN)
				{
					_clickValid = false;
				}
				
				if (_touchWrap.phase == TouchPhase.Ended && _clickValid)
				{
					_clickHander(_touchWrap.position);
					_clickValid = false;
				}
			}
		}
		else
		{
			_clickValid = false;
		}
	}
}

using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	void OnEnable()  
	{  
		EasyJoystick.On_JoystickMove += OnJoystickMove;  
		
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;  
	}  
	
	//移动摇杆结束  
	
	void OnJoystickMoveEnd(MovingJoystick move)  
	{  
		//停止时，角色恢复idle  
		if (move.joystickName == "MoveJoystick")  
			
		{  
		}  
	}  
	

	//移动摇杆中  
	
	void OnJoystickMove(MovingJoystick move)  
	{  
		if (move.joystickName != "MoveJoystick")  
		{  
			return;  
		}  

		//获取摇杆中心偏移的坐标  
		
		float joyPositionX = move.joystickAxis.x;  
		
		float joyPositionY = move.joystickAxis.y;  
		
		if (joyPositionY != 0 || joyPositionX != 0)  
		{  
//			移动玩家的位置（按朝向位置移动）
//			Debug.Log("joyPositionX :" + joyPositionX + "joyPositionY" + joyPositionY);
			transform.Translate(new Vector3(joyPositionX/5, 0, joyPositionY/5));  
		}  
	}  
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	
	public float walkSpeed;

	public VirtualJoystick joystick;

	void Start()
	{
			
	}


	void FixedUpdate()
	{
		// Move senteces
		transform.position = new Vector2(transform.position.x + joystick.Horizontal()* walkSpeed *Time.deltaTime,
			transform.position.y + joystick.Vertical()* walkSpeed *Time.deltaTime);
		 
	}
}

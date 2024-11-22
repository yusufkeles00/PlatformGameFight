using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
	[SerializeField]
	PlayerScript playerScript;

	public void MoveRight()
	{
		Debug.Log("Right");
		playerScript.horizontalInput = 1;
	}
	public void MoveLeft()
	{
		Debug.Log("Left");
		playerScript.horizontalInput = -1;
	}

	public void StopMove()
	{
		Debug.Log("Stop");
		playerScript.horizontalInput = 0;
	}
}

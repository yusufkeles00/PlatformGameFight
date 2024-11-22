using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[SerializeField]
	PlayerScript playerScript;

	private void Update()
	{
		playerScript.horizontalInput = Input.GetAxisRaw("Horizontal");
	}
}

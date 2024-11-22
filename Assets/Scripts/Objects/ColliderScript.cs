using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
	int number = 0;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Platform"))
		{
			number = 1;
		}
		if (collision.CompareTag("Player") && number == 1)
		{
			collision.GetComponent<PlayerScript>().readyToPush = 1;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Platform"))
		{
			number = 0;
		}
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerScript>().readyToPush = 0;
		}
	}
}

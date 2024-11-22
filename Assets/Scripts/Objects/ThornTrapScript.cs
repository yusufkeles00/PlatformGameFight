using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrapScript : MonoBehaviour
{
	public int num = 1;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (num == 1)
			{
				num = 0;
				collision.GetComponent<PlayerCollision>().PlayerDead();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			num = 1;
		}
	}
}

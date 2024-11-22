using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{
	public GameObject destroyEffect;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

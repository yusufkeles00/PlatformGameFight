using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
	public GameObject coinParticleEffect;

	private int coinIndex = 1;

	void DestroyCoin()
	{
		Instantiate(coinParticleEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (coinIndex != 0)
		{
			if (collision.CompareTag("Player"))
			{
				collision.GetComponent<PlayerScript>().coinMngSc.coinPoint++;
				coinIndex = 0;
				DestroyCoin();
			}
		}
	}
}

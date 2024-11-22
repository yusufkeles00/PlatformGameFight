using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitSlimeBulletScriptLeft : MonoBehaviour
{
	public Rigidbody2D spitSlimeBulletRb;

	public GameObject spitSlimeBulletDestroyEffect;

	private float bulletLifeTime = 4.2f;
	public float bulletSpeed;


	private void Start()
	{
		Invoke("DestroySpitBullet", bulletLifeTime);
	}

	private void FixedUpdate()
	{
		spitSlimeBulletRb.velocity = new Vector2(-bulletSpeed * Time.deltaTime, spitSlimeBulletRb.velocity.y);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerScript>().guiltyCharacter = collision.GetComponent<PlayerScript>().cameraScript.gameObject;
			collision.GetComponent<PlayerCollision>().PlayerDead();
			Invoke("DestroySpitBullet", 0.02f);
		}

		if (collision.CompareTag("Platform"))
		{
			Invoke("DestroySpitBullet", 0.01f);
		}

		if (collision.CompareTag("WoodBox"))
		{
			Invoke("DestroySpitBullet", 0.01f);
		}
	}

	public void DestroySpitBullet()
	{
		Instantiate(spitSlimeBulletDestroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}

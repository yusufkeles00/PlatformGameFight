using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBulletSc : MonoBehaviour
{
	public GameObject crabBulletParticle;

	private Rigidbody2D crabBulletRb;
	private Animator crabBulletAnim;

	public float bulletLifeTime;

	private void Start()
	{
		crabBulletRb = GetComponent<Rigidbody2D>();
		crabBulletAnim = GetComponent<Animator>();
		Invoke("DestroyBullet", bulletLifeTime);
	}

	void DestroyBullet()
	{
		crabBulletAnim.SetTrigger("DestroyBullet");
		Destroy(gameObject, 0.5f);
		Instantiate(crabBulletParticle, transform.position, Quaternion.identity);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerScript>().guiltyCharacter = GameObject.FindGameObjectWithTag("CrabEnemy").gameObject;
			collision.GetComponent<PlayerCollision>().PlayerDead();
		}
	}
}

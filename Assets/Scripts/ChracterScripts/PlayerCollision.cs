using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	[SerializeField]
	PlayerScript playerScript;

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Platform") || collision.CompareTag("WoodBox"))
		{
			playerScript.number = 0;
			playerScript.playerAnim.SetBool("Jump", false);
			playerScript.playerAnim.SetBool("Fall", false);
			if (collision.CompareTag("Platform"))
			{
				Instantiate(playerScript.groundCrashEffect, playerScript.pos.position, Quaternion.identity);
			}
			playerScript.jumpCounter = playerScript.NumOfJump;
		}
		if (collision.CompareTag("SpeedBoostTag"))
		{
			playerScript.trialEffect.SetActive(true);
			playerScript.moveSpeed += playerScript.boostedSpeed;
			StartCoroutine("SpeedBoostTimer");
		}
		if (collision.CompareTag("DoubleJumpBoostTag"))
		{
			playerScript.NumOfJump = 2;
			playerScript.jumpCounter = 2;
			StartCoroutine("DoubleJumpTimer");
		}
	}

	public void TakeDamage(int damage)
	{
		if (playerScript.playerCurrentHealth > 0)
		{
			playerScript.playerCurrentHealth -= damage;
		}
		if (playerScript.playerCurrentHealth <= 0)
		{
			PlayerDead();
		}
	}

	public void PlayerDead()
	{
		Destroy(gameObject);
		Instantiate(playerScript.playerDeadParticleEffect, playerScript.transform.position, Quaternion.identity);
		//Change the camera focus from character to guiltyCharacter
		playerScript.cameraScript.target = playerScript.guiltyCharacter;
		playerScript.isAlive = false;
	}
	IEnumerator DoubleJumpTimer()
	{
		yield return new WaitForSeconds(playerScript.doubleJumpBoostTime);
		playerScript.NumOfJump = 1;
	}

	IEnumerator SpeedBoostTimer()
	{
		yield return new WaitForSeconds(playerScript.speedBoostTime);

		playerScript.moveSpeed -= playerScript.boostedSpeed;
		playerScript.trialEffect.SetActive(false);
	}
}

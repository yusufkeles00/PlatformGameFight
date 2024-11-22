using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	PlayerScript playerScript;

	private void Update()
	{
		if (playerScript.isAlive == true)
		{
			PlayerMove();
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				PlayerJump();
			}
		}
		else if (playerScript.isAlive == false)
		{
			StartCoroutine("DieDelay");
		}
	}

	void PlayerMove()
	{
		playerScript.playerRb.velocity = new Vector2(playerScript.horizontalInput * playerScript.moveSpeed, playerScript.playerRb.velocity.y);
		if (playerScript.horizontalInput > 0 && playerScript.isFaceRight == false)
		{
			FlipFace();
		}
		else if (playerScript.horizontalInput < 0 && playerScript.isFaceRight == true)
		{
			FlipFace();
		}
		if (playerScript.horizontalInput != 0)
		{
			playerScript.playerAnim.SetBool("isRunning", true);
		}
		else
		{
			playerScript.playerAnim.SetBool("isRunning", false);
		}

		if (playerScript.horizontalInput != 0 && playerScript.jumpCounter == 1)
		{
			playerScript.dustEmission.rateOverTime = 7f;
		}
		else
		{
			playerScript.dustEmission.rateOverTime = 0f;
		}
		if (playerScript.readyToPush == 1 && playerScript.horizontalInput != 0)
		{
			playerScript.playerAnim.SetBool("isPushing",true);
		}
		else if (playerScript.horizontalInput == 0)
		{
			playerScript.playerAnim.SetBool("isPushing", false);
		}
		else if (playerScript.readyToPush != 1)
		{
			playerScript.playerAnim.SetBool("isPushing", false);
		}
	}

	public void PlayerJump()
	{
		playerScript.number = 1;
		if (playerScript.jumpCounter > 0)
		{
			playerScript.playerAnim.SetBool("Jump", true);
			playerScript.playerRb.AddForce(Vector2.up * playerScript.jumpForce);
			playerScript.jumpCounter -= 1;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Platform") || collision.CompareTag("WoodBox"))
		{
			if (playerScript.NumOfJump != 2)
			{
				playerScript.jumpCounter = 0;
			}
			if (playerScript.number != 1)
			{
				playerScript.playerAnim.SetBool("Fall", true);
			}
		}
	}

	void FlipFace()
	{
		playerScript.isFaceRight = !playerScript.isFaceRight;
		playerScript.transform.Rotate(0f, 180f, 0f);
	}

	IEnumerator DieDelay()
	{
		yield return new WaitForSeconds(0.3f);
		playerScript.playerRb.velocity = new Vector2(0, playerScript.playerRb.velocity.y);
	}
}

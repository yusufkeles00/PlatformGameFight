using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornEnemyScript : MonoBehaviour
{
	private Rigidbody2D thornEnemyRb;
	private Animator thornEnemyAnim;

	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private bool isThornEnemyFaceRight = false;

	private void Start()
	{
		thornEnemyRb = GetComponent<Rigidbody2D>();
		thornEnemyAnim = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		Patrol();
	}

	void Patrol()
	{
		thornEnemyRb.velocity = new Vector2(moveSpeed * Time.deltaTime, thornEnemyRb.velocity.y);
		if (moveSpeed != 0)
		{
			thornEnemyAnim.SetBool("isWalkingThornEnemy", true);
		}

		if (isThornEnemyFaceRight == false && moveSpeed < 0 )
		{
			ThornEnemyFlipFace();
		}
		else if (isThornEnemyFaceRight == true && moveSpeed > 0)
		{
			ThornEnemyFlipFace();
		}
	}

	void ThornEnemyFlipFace()
	{
		isThornEnemyFaceRight = !isThornEnemyFaceRight;
		transform.Rotate(0f, 180f, 0f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("TurnLeft") && moveSpeed > 0)
		{
			moveSpeed *= -1;
		}
		else if (collision.CompareTag("TurnRight") && moveSpeed < 0)
		{
			moveSpeed *= -1;
		}

		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerScript>().guiltyCharacter = gameObject;
			collision.GetComponent<PlayerCollision>().PlayerDead();
		}
	}

}

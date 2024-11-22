using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemyScript : MonoBehaviour
{
	public EasyEnemyAI enemyAI;
	public DetectorScript detectorSc;
	public EasyEnemyAttack enemyAttack;

	public PlayerScript player;

	public GameObject deadEffect;

	public Rigidbody2D easyEnemyRb;
	public Animator easyEnemyAnim;

	public LayerMask patrollingLayer;
	private RaycastHit2D enemyHit;
	private Vector2 dir;

	public float moveSpeed;
	public float deadForce;
	public float rayDistance;

	public int deadIndex = 1;

	public bool isEnemysFaceRight = false;

	private void Start()
	{
		dir = Vector2.right;
	}

	private void Update()
	{
		Move();
		enemyHit = Physics2D.Raycast(transform.position, dir, rayDistance,patrollingLayer);
		CheckPatrol();
		Debug.DrawRay(transform.position, dir * rayDistance);
	}

	void Move()
	{
		easyEnemyRb.velocity = new Vector2(moveSpeed, easyEnemyRb.velocity.y);

		if (moveSpeed != 0)
		{
			easyEnemyAnim.SetBool("isMoving", true);
		}

		if (enemyAI.canChase == false)
		{
			if (isEnemysFaceRight == false && moveSpeed > 0)
			{
				FlipFace();
			}
			else if (isEnemysFaceRight == true && moveSpeed < 0)
			{
				FlipFace();
			}
		}
	}

	void CheckPatrol()
	{
		if (enemyHit.collider != null)
		{
			if (enemyHit.collider.gameObject.CompareTag("TurnLeft") && moveSpeed > 0 )
			{
				dir = Vector2.left;
				moveSpeed *= -1;
			}
			else if (enemyHit.collider.gameObject.CompareTag("TurnRight") && moveSpeed < 0)
			{
				dir = Vector2.right;
				moveSpeed *= -1;
			}
		}
	}

	public void FlipFace()
	{
		isEnemysFaceRight = !isEnemysFaceRight;
		transform.Rotate(0f, 180f, 0f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && deadIndex == 1)
		{
			deadIndex = 0;
			player.playerRb.velocity = new Vector2(player.transform.position.x, 0);
			player.playerRb.AddForce(Vector2.up * deadForce);
			moveSpeed = 0f;
			easyEnemyAnim.SetTrigger("Squash");
			StartCoroutine(SquashDelay());
		}

		if (collision.CompareTag("WoodBox") && deadIndex == 1)
		{
			deadIndex = 0;
			moveSpeed = 0f;
			easyEnemyAnim.SetTrigger("Squash");
			StartCoroutine(SquashDelay());
		}
	}

	IEnumerator SquashDelay()
	{
		yield return new WaitForSeconds(0.17f);

		EnemyDead();
	}

	void EnemyDead()
	{
		Instantiate(deadEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}

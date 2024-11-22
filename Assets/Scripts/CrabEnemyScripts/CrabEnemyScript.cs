using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemyScript : MonoBehaviour
{
	public PlayerScript playerSc;
	public CrabBulletSpawnerSc crabBulletSpawnerScript;

	private Animator crabEnemyAnim;
	private Rigidbody2D crabEnemyRB;

	public GameObject crabDeadParticle;

	public Collider2D crabCollider;

	[SerializeField] bool isCrabEnemysFaceRight = false;
	public bool isHeadOpen = false;

	[SerializeField] int shotCounter = 2;
	[SerializeField] int shotLoopCounter = 2;
	[SerializeField] int deadForce;

	[SerializeField] float crabEnemySpeed;
	[SerializeField] float shotTimer = 7f;



	private void Start()
	{
		crabEnemyAnim = GetComponent<Animator>();
		crabEnemyRB = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		CrabEnemyPatrolling();
		shotTimer -= Time.deltaTime;
	}

	private void Update()
	{
		if (isHeadOpen)
		{
			crabCollider.enabled = true;
		}
		else if (isHeadOpen == false)
		{
			crabCollider.enabled = false;
		}
	}

	private void CrabEnemyPatrolling()
	{
		crabEnemyRB.velocity = new Vector2(crabEnemySpeed * Time.deltaTime, crabEnemyRB.velocity.y);
		if (crabEnemySpeed != 0)
		{
			crabEnemyAnim.SetBool("isWalking", true);
		}
		else if (crabEnemySpeed == 0)
		{
			crabEnemyAnim.SetBool("isWalking", false);
		}

		if (crabEnemySpeed < 0 && isCrabEnemysFaceRight == true)
		{
			CrabEnemyFlipFace();
		}
		else if (crabEnemySpeed > 0 && isCrabEnemysFaceRight == false)
		{
			CrabEnemyFlipFace();
		}

		if (shotTimer < 0 && shotTimer > -0.3)
		{
			StartCoroutine("GoToShotPos");
		}
	}

	IEnumerator GoToShotPos()
	{
		crabEnemySpeed = 0;
		crabEnemyAnim.SetBool("OpenUpHead",true);
		isHeadOpen = true;
		yield return new WaitForSeconds(0.6f);
		crabEnemyAnim.SetBool("OpenUpHead", false);
		StartCoroutine("Shot");
	}

	IEnumerator Shot()
	{
		if (shotCounter >= 0)
		{
			crabEnemyAnim.SetTrigger("Shot");
			if (shotLoopCounter == 2)
			{
				crabBulletSpawnerScript.counter = 1;
				crabBulletSpawnerScript.Invoke("ShotLaser1", 1f);
			}
			else if (shotLoopCounter == 1)
			{
				crabBulletSpawnerScript.twoCounter = 1;
				crabBulletSpawnerScript.Invoke("ShotLaser2", 0.7f);
			}
			yield return new WaitForSeconds(0.8f);
			shotCounter -= 1;
			shotLoopCounter--;
			StartCoroutine("Shot");
		}

		StartCoroutine("GoPatrol");
	}

	IEnumerator GoPatrol()
	{
		crabEnemyAnim.SetTrigger("CloseUpHead");

		yield return new WaitForSeconds(2.6f);

		isHeadOpen = false;
		shotTimer = 2f;
		shotCounter = 2;
		shotLoopCounter = 2;

		crabEnemyAnim.SetBool("isWalking", true);
		if (isCrabEnemysFaceRight == true)
		{
			crabEnemySpeed = 60;
		}
		else if (isCrabEnemysFaceRight == false)
		{
			crabEnemySpeed = -60;
		}
	}

	void CrabEnemyFlipFace()
	{
		isCrabEnemysFaceRight = !isCrabEnemysFaceRight;
		transform.Rotate(0, 180, 0);
	}

	void CrabDead()
	{
		crabEnemyAnim.SetTrigger("Dead");
		StartCoroutine("CrabDeadAnim");
	}

	IEnumerator CrabDeadAnim()
	{
		yield return new WaitForSeconds(0.3f);
		Destroy(gameObject);
		Instantiate(crabDeadParticle, transform.position, Quaternion.identity);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("TurnLeft") && crabEnemySpeed > 0)
		{
			crabEnemySpeed *= -1;
		}
		else if (collision.CompareTag("TurnRight") && crabEnemySpeed < 0)
		{
			crabEnemySpeed *= -1;
		}
		//Kill or Dead!
		if (isHeadOpen == true)
		{
			if (collision.CompareTag("Player"))
			{
				playerSc.playerRb.AddForce(Vector2.up * deadForce);
				CrabDead();
			}
		}
		else if (isHeadOpen == false)
		{
			if (collision.CompareTag("Player"))
			{
				collision.GetComponent<PlayerScript>().guiltyCharacter = GameObject.FindGameObjectWithTag("CrabEnemy").gameObject;
				collision.GetComponent<PlayerCollision>().PlayerDead();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (isHeadOpen == false)
		{
			if (collision.transform.CompareTag("Player"))
			{
				playerSc.guiltyCharacter = gameObject;
				playerSc.playerCollison.PlayerDead();
			}
		}
	}
}

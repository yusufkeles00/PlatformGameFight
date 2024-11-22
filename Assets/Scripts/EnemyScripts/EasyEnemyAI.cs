using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemyAI : MonoBehaviour
{
	public EasyEnemyScript enemy;

	public GameObject playerObject;
	public GameObject SurpiseFx;

	private Color color;

	private Vector2 enemyPos;
	public Vector3 enemyOffset;

	public bool canChase = false;
	public float distanceBtwEnemyPlayer;
	public float chasingSpeed;

	private void Start()
	{
		distanceBtwEnemyPlayer = 5f;	
	}

	private void Update()
	{
		EnemyChasing();
		distanceBtwEnemyPlayer = Vector2.Distance(transform.position, playerObject.transform.position);

		if (distanceBtwEnemyPlayer >= 10 && enemy.moveSpeed == 0)
		{
			enemy.detectorSc.detectorIndex = 1;
			StopChasing();
		}
		//Debug.Log(distanceBtwEnemyPlayer);
	}

	public IEnumerator Surprising()
	{
		canChase = false;
		enemy.moveSpeed = 0;
		Instantiate(SurpiseFx, transform.position + enemyOffset, Quaternion.identity);
		enemy.easyEnemyAnim.Play("EasyEnemySurprisedAnim", 0, 0.1f);
		//enemy.easyEnemyAnim.SetTrigger("Surprise");

		yield return new WaitForSeconds(1.3f);
		canChase = true;
	}

	public void EnemyChasing()
	{
		enemyPos = new Vector2(playerObject.transform.position.x, transform.position.y);
		if (canChase == true && distanceBtwEnemyPlayer > 1.4f)
		{
			transform.position = Vector2.MoveTowards(transform.position, enemyPos, chasingSpeed * Time.deltaTime);
			enemy.easyEnemyAnim.SetBool("isChasing", true);
			if (playerObject.transform.position.x > transform.position.x && enemy.isEnemysFaceRight == false)
			{
				enemy.FlipFace();
			}
			else if (playerObject.transform.position.x < transform.position.x && enemy.isEnemysFaceRight == true)
			{
				enemy.FlipFace();
			}
		}
	}

	void ContinuePatrol()
	{
		enemy.moveSpeed = 2;
		enemy.easyEnemyAnim.Play("EasyEnemyWalkAnim", 0, 0.1f);
	}

	public void StopChasing()
	{
		enemy.easyEnemyAnim.SetBool("isChasing", false);
		canChase = false;
		ContinuePatrol();
	}
}

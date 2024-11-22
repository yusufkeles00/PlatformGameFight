using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemyAttack : MonoBehaviour
{
	public EasyEnemyScript enemy;

	private int attackIndex = 1;
	public int attackDamage = 100;

	private void Update()
	{
		if (enemy.enemyAI.distanceBtwEnemyPlayer <= 1.4f && attackIndex == 1 && enemy.enemyAI.canChase == true && enemy.detectorSc.enemyDeadIndex == 0)
		{
			Debug.Log("XXX");
			StartCoroutine(EnemyAttack());
		}
		else if (enemy.enemyAI.distanceBtwEnemyPlayer > 1.4f)
		{
			attackIndex = 1;
		}
	}

	IEnumerator EnemyAttack()
	{
		attackIndex = 0;
		yield return new WaitForSeconds(0.15f);
		enemy.easyEnemyAnim.SetTrigger("Attack");
		StartCoroutine(AttackDelay());
		enemy.player.playerCollison.PlayerDead();
	}

	IEnumerator AttackDelay()
	{
		yield return new WaitForSeconds(0.4f);
	}
}

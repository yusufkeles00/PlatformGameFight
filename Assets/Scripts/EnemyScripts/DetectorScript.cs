using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour
{
	public EasyEnemyScript enemy;

	public int detectorIndex = 1;
	public int enemyDeadIndex = 1;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && detectorIndex == 1)
		{
			detectorIndex = 0;
			enemyDeadIndex = 0;
			StartCoroutine(enemy.enemyAI.Surprising());
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			enemyDeadIndex = 1;
		}
	}
}

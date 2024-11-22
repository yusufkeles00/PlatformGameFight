using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBulletSpawnerSc : MonoBehaviour
{
	public GameObject crabBulletObj;

	public Transform target1;
	public Transform target2;
	public Transform target3;
	public Transform target4;

	private GameObject crabBulletClone1;
	private GameObject crabBulletClone2;
	private GameObject crabBulletClone3;
	private GameObject crabBulletClone4;

	private GameObject crabBulletClone5;
	private GameObject crabBulletClone6;
	private GameObject crabBulletClone7;
	private GameObject crabBulletClone8;

	public float crabBulletMoveSpeed;

	public int counter;
	private int counter2;

	public int twoCounter;
	private int twoCounter2;

	private void Start()
	{
		counter = 0;
		counter2 = 0;
		twoCounter = 0;
		twoCounter2 = 0;
	}

	private void FixedUpdate()
	{
		if (counter2 == 1)
		{
			crabBulletClone1.transform.position = Vector2.MoveTowards(crabBulletClone1.transform.position, target1.position, crabBulletMoveSpeed * Time.deltaTime);
			crabBulletClone2.transform.position = Vector2.MoveTowards(crabBulletClone2.transform.position, target2.position, crabBulletMoveSpeed * Time.deltaTime);
			crabBulletClone3.transform.position = Vector2.MoveTowards(crabBulletClone3.transform.position, target3.position, crabBulletMoveSpeed * Time.deltaTime);
			crabBulletClone4.transform.position = Vector2.MoveTowards(crabBulletClone4.transform.position, target4.position, crabBulletMoveSpeed * Time.deltaTime);
		}
		if (twoCounter2 == 1)
		{
			crabBulletClone5.transform.position = Vector2.MoveTowards(crabBulletClone5.transform.position, target1.position, crabBulletMoveSpeed * Time.deltaTime);
			crabBulletClone6.transform.position = Vector2.MoveTowards(crabBulletClone6.transform.position, target2.position, crabBulletMoveSpeed * Time.deltaTime);
			crabBulletClone7.transform.position = Vector2.MoveTowards(crabBulletClone7.transform.position, target3.position, crabBulletMoveSpeed * Time.deltaTime);
			crabBulletClone8.transform.position = Vector2.MoveTowards(crabBulletClone8.transform.position, target4.position, crabBulletMoveSpeed * Time.deltaTime);
		}
	}

	void ShotLaser1()
	{
		while (counter == 1)
		{
			crabBulletClone1 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			crabBulletClone2 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			crabBulletClone3 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			crabBulletClone4 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			counter = 0;
			counter2 = 1;
			//StartCoroutine("StopMovingBullets1");
		}
	}

	void ShotLaser2()
	{
		while (twoCounter == 1)
		{
			crabBulletClone5 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			crabBulletClone6 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			crabBulletClone7 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			crabBulletClone8 = Instantiate(crabBulletObj, transform.position, Quaternion.identity);
			twoCounter = 0;
			twoCounter2 = 1;
			//StartCoroutine("StopMovingBullets2");
		}
	}

	/*
	IEnumerator StopMovingBullets1()
	{
		yield return new WaitForSeconds(2.5f);
		counter2 = 0;
	}

	IEnumerator StopMovingBullets2()
	{
		yield return new WaitForSeconds(2.5f);
		twoCounter2 = 0;
	}
	*/
}

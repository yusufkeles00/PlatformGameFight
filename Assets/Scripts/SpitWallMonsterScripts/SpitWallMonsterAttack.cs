using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitWallMonsterAttack : MonoBehaviour
{
	private Animator spitWallMonsterAnim;

	public GameObject spitSlimeBulletObject;
	public GameObject spitWallMonsterShotParticles;

	public Transform shotPos;

	public float attackRepeatTime;

	private void Start()
	{
		spitWallMonsterAnim = GetComponent<Animator>();
		InvokeRepeating("SpitWallMonsterAttackFunc", 1f, attackRepeatTime);
	}

	void SpitWallMonsterAttackFunc()
	{
		//Play Attack Anim
		spitWallMonsterAnim.SetTrigger("SpitMonsterAttack");

		//Wait  second for animation
		StartCoroutine("SpitWallMonsterAttackDelay");

		//Spawn SpitBullet And Play sound
		Instantiate(spitWallMonsterShotParticles, shotPos.position, Quaternion.identity);
		Instantiate(spitSlimeBulletObject, shotPos.position, Quaternion.identity);
	}

	IEnumerator SpitWallMonsterAttackDelay()
	{
		yield return new WaitForSeconds(0.3f);
	}
}

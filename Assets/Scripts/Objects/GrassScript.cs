using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{
	public Animator grassAnim;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			ShakeGrasses(grassAnim);
		}
	}

	void ShakeGrasses(Animator anim)
	{
		anim.SetTrigger("ShakeGrass");
	}
}

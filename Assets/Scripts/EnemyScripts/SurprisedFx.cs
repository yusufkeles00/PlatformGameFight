using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurprisedFx : MonoBehaviour
{
	private Animator FxAnim;

	private void Start()
	{
		FxAnim = GetComponent<Animator>();
		Destroy(gameObject, 2.5f);
	}
}

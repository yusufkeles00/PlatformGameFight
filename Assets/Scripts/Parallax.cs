using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	public GameObject cam;

	private float lenght, startPos;
	public float parallaxEffect;

	private void Start()
	{
		startPos = transform.position.x;
		lenght = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	private void Update()
	{
		float temp = (cam.transform.position.x * (1 - parallaxEffect));
		float distance = (cam.transform.position.x * parallaxEffect);

		transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

		if (temp > startPos + lenght)
		{
			startPos += lenght;
		}
		else if (temp < startPos - lenght)
		{
			startPos -= lenght;
		}
	}
}

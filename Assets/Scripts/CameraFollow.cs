using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	PlayerScript playerScript;

	public GameObject target;

	public Vector3 offset;
	public Vector3 minValues, maxValues;

	public float delay;

	private void Start()
	{

	}

	private void FixedUpdate()
	{
		//Bound position
		Vector3 boundPos = new Vector3(
			Mathf.Clamp(target.transform.position.x, minValues.x, maxValues.x),
			Mathf.Clamp(target.transform.position.y, minValues.y, maxValues.y),
			Mathf.Clamp(target.transform.position.z, minValues.z, maxValues.z));

		//Follow the Character
		transform.position = Vector3.Lerp(transform.position, boundPos + offset, delay);
	}
}

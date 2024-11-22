using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	private Rigidbody2D platformRb;

	public Transform pos1, pos2;
	public Transform startPos;

	public float velocity;
	public float rePosDistance;

	private void Start()
	{
		velocity = 2f;
		platformRb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		platformRb.velocity = new Vector2(platformRb.velocity.x, velocity);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("TargetPos1"))
		{
			velocity = -2f;
		}
		if (collision.CompareTag("TargetPos2"))
		{
			velocity = 2f;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(pos1.position, pos2.position);
	}
}

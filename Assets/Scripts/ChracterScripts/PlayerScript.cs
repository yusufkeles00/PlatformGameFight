using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public PlayerMovement playerMovement;
	public PlayerInput playerInput;
	public PlayerCollision playerCollison;
	public TouchControls touchControls;
	public CameraFollow cameraScript;

	public CoinMngScript coinMngSc;

	public GameObject playerDeadParticleEffect;
	public GameObject groundCrashEffect;
	public GameObject trialEffect;
	public GameObject guiltyCharacter;

	public Rigidbody2D playerRb;
	public Animator playerAnim;

	public Transform pos;

	public ParticleSystem dustEfffect;
	public ParticleSystem.EmissionModule dustEmission;

	public float doubleJumpBoostTime;
	public float speedBoostTime;
	public float boostedSpeed;

	public float horizontalInput;
	public float moveSpeed;
	public float jumpForce;

	public int playerMaxHealth;
	public int playerCurrentHealth;

	public int readyToPush = 0;
	public int NumOfJump = 1;
	public int jumpCounter = 1;
	public int number = 0;

	public bool isAlive = true;
	public bool isFaceRight = false;

	private void Start()
	{
		dustEmission = dustEfffect.emission;
		playerCurrentHealth = playerMaxHealth;
	}

	private void Update()
	{
		trialEffect.transform.position = transform.position;
	}
}

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

	public int attackDamage = 10;               // The amount of health taken away per attack.

	private float speed;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f;
	private float baseSpeed = 0.20f;

	private AudioSource audioSource;
	public RandomSound skeletonGrowlRandomSounds;

	private Rigidbody2D rigidBody;
	private Animator animator;
	private bool isMoving;
	private Vector2 direction;
	private float lastX;
	private PlayerHealth playerHealth;                  // Reference to the player's health.
	private bool attackModeOn = false;
	private float lastAttackDelay;

	// Use this for initialization
	void Start()
	{
		audioSource = this.GetComponent<AudioSource>();
		animator = this.GetComponent<Animator>();
		rigidBody = this.GetComponent<Rigidbody2D>();

		playerHealth = GameObject.FindObjectOfType<PlayerHealth> ();
		direction = new Vector2(-this.transform.localScale.x, 0);
		lastAttackDelay = 0;
	}

	// Update is called once per frame
	void Update()
	{
		LOS();
		if(!this.attackModeOn)
			RetardPatrol();
	}

	void LOS()
	{
		Vector2 rayEnemyOrig = new Vector2(transform.position.x + (0.2f * direction.x), transform.position.y);
		RaycastHit2D hitEnemy = Physics2D.Raycast(rayEnemyOrig, direction);

		Vector2 rayFallOrig = new Vector2(transform.position.x + (0.2f * direction.x), transform.position.y);
		RaycastHit2D hitFall = Physics2D.Raycast(rayFallOrig, Vector2.down);

		//Vector3 r = new Vector3(transform.position.x + (0.1f * direction.x), transform.position.y, transform.position.z);
		//Debug.DrawLine(r, hitFall.point, Color.cyan);

		if (hitFall.collider != null)
		{
			if (hitFall.collider.gameObject.name == "void" || hitFall.collider.gameObject.name == "Skeleton")
			{
				ChangePatrolDirection();
			}
		}   

		if (hitEnemy.collider != null)
		{
			if (hitEnemy.collider.gameObject.name == "Knight")
			{
				if (!audioSource.isPlaying)
				{
					this.audioSource.PlayOneShot(skeletonGrowlRandomSounds.GetRandomSound());
				}
				baseSpeed = 0.45f;
			}
			else
			{
				baseSpeed = 0.20f;
			}
		}
		else
		{
			baseSpeed = 0.20f;
		}
	}

	void RetardPatrol()
	{
		if (direction == Vector2.left)
		{
			speed = -baseSpeed;
		}
		else if(direction == Vector2.right)
		{
			speed = baseSpeed;
		}

		this.animator.SetBool("moving", speed != 0);

		if (speed != 0)
		{
			float sX = speed < 0 ? scaleX : -scaleX;
			transform.localScale = new Vector2(sX, scaleY);

		}

		this.rigidBody.velocity = new Vector2(speed, this.rigidBody.velocity.y);
	}

	public void ChangePatrolDirection()
	{
		if (this.direction == Vector2.left)
			this.direction = Vector2.right;
		else if (this.direction == Vector2.right)
			this.direction = Vector2.left;
	}

	public void Attack ()
	{
		this.attackModeOn = true;

		if (playerHealth.currentHealth > 0 && (this.lastAttackDelay == 0 || this.lastAttackDelay >= 0.5))
		{
			this.animator.SetTrigger("attack");
			playerHealth.TakeDamage (attackDamage);
			this.lastAttackDelay = 0;
		}

		this.lastAttackDelay += Time.deltaTime;
	}

	public void Stop()
	{
		this.speed = 0;
		this.animator.SetBool("moving", false);
	}

	public void RestartPatrol()
	{
		this.attackModeOn = false;
	}
}

using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

	public int attackDamage = 10;               // The amount of health taken away per attack.

	private float speed;
    private float scaleX = 1.0f;
    private float scaleY = 1.0f;
    private float baseSpeed = 0.20f;
    private AudioSource audioSource;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private bool isMoving;
    private Vector2 direction;
    private float lastX;
	private PlayerHealth playerHealth;                  // Reference to the player's health.
	private GameObject player;                          // Reference to the player GameObject.

    // Use this for initialization
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        direction = new Vector2(-this.transform.localScale.x, 0);
=======
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = GameObject.FindObjectOfType<PlayerHealth> ();
        direction = Vector2.left;
>>>>>>> origin/master
    }

    // Update is called once per frame
    void Update()
    {
        LOS();
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
            if (hitFall.collider.gameObject.name == "void")
            {
                ChangePatrolDirection();
            }
        }   

        if (hitEnemy.collider != null)
        {
<<<<<<< HEAD
            if (hitEnemy.collider.gameObject.name == "Knight")
=======
			if (hitEnemy.collider.gameObject == player)
>>>>>>> origin/master
            {
				Attack ();
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
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

        if (speed < 0)
        {
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if (speed > 0)
        {
            transform.localScale = new Vector2(-scaleX, scaleY);
        }
        if (speed == 0)
        {
            this.animator.Play("idle_skel");
        }
        else
        {
            this.animator.Play("walk_skel");
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

	void Attack ()
	{
		// If the player has health to lose...
		if(playerHealth.currentHealth > 0)
		{
			// ... damage the player.
			playerHealth.TakeDamage (attackDamage);
		}
	}
   
}

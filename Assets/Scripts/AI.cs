using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{
    private float speed;
    private float scaleX = 1.0f;
    private float scaleY = 1.0f;
    private float baseSpeed = 0.3f;
    private AudioSource audioSource;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private bool isMoving;
    private Vector2 direction;
    private float lastX;

    // Use this for initialization
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        LOS();
        RetardPatrol();
    }

    void LOS()
    {
        Vector2 rayOrig = new Vector2(transform.position.x + (0.2f * direction.x), transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrig, direction);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name == "knightSprite_1")
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

            }
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
        this.direction = Vector2.right;
    }
   
}

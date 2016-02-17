using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public LevelManager levelManager;

    public float speed = 1.0f;
    public float jumpSpeed = 50.0f;

    public bool grounded = true;
    private bool stuckOnWall;
    private Animator playerAnimator;
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;

    private float scaleX = 1.0f;
    private float scaleY = 1.0f;

    public AudioClip fall;
    public RandomSound jumpRandomSounds;

    private float jumpDelay;


    // Use this for initialization
    void Start()
    {
        playerAnimator = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidBody.WakeUp();
        float mSpeed = Input.GetAxis("Horizontal");

      
        
        if (Input.GetKey(KeyCode.Space) && this.grounded && this.jumpDelay >= 0.3)
        {
            this.jumpDelay = 0;
            this.rigidBody.AddForce(Vector2.up * jumpSpeed * 7);

            if (!this.audioSource.isPlaying) {
                this.audioSource.PlayOneShot(this.jumpRandomSounds.GetRandomSound());
            }
        }
        
        this.jumpDelay += Time.deltaTime;

        if (!this.grounded)
        {
            this.playerAnimator.Play("air");
        }
        else
        {

            if (mSpeed > 0)
            {
                transform.localScale = new Vector2(scaleX, scaleY);
            }
            else if (mSpeed < 0)
            {
                transform.localScale = new Vector2(-scaleX, scaleY);
            }

            if (mSpeed == 0)
            {
                this.playerAnimator.Play("idle");
            }
            else
            {
                this.playerAnimator.Play("walk");
            }
        }

        if (this.grounded || !this.stuckOnWall)
        {
            this.rigidBody.velocity = new Vector2(mSpeed * speed, this.rigidBody.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "void")
        {
            if (!this.audioSource.isPlaying)
            {
                this.audioSource.Stop();
            }
            this.audioSource.PlayOneShot(fall);
            Destroy(other.gameObject);
            Invoke("EndScreen", fall.length);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        this.stuckOnWall = coll.gameObject.name == "Walls";
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        this.stuckOnWall = coll.gameObject.name == "Walls";
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        this.stuckOnWall = coll.gameObject.name == "Walls";
    }

    void EndScreen()
    {
        levelManager.LoadLevel("End");
    }
}

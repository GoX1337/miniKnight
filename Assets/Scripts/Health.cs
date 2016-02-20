using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int startingHealth = 100;                           
    public int currentHealth;
    protected bool damaged = false;
    public bool isDead = false;
    private AudioSource audioSource;
    private Animator animator;
    public RandomSound hitRandomSounds;
    public GameObject owner;
    private AI ai;
    private GameObject attackArea;

	// Use this for initialization
	void Start () {
        this.currentHealth = startingHealth;
        this.audioSource = GetComponent<AudioSource>();
        this.animator = GetComponent<Animator>();
        this.ai = GetComponent<AI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(int amount)
    {
        //Debug.Log(owner.name + " took " + amount + " dmg");
        this.audioSource.PlayOneShot(this.hitRandomSounds.GetRandomSound());
        damaged = true;
        currentHealth -= amount;
        
        if (currentHealth <= 0 && !isDead)
        {
            Death();
            isDead = true;
        }
    }

    public void Death()
    {
        if (!isDead) 
        { 
            Destroy(ai);
            Destroy(this.transform.Find("AttackArea").gameObject);
            this.animator.SetTrigger("dead");
        }
    }
}

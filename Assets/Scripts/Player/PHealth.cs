using UnityEngine;
using System.Collections;

public class PHealth : MonoBehaviour {

    public int startingHealth = 100;                           
    public int currentHealth;
    protected bool damaged = false;
    public bool isDead = false;
    private AudioSource audioSource;
    private Animator animator;
    public RandomSound hitRandomSounds;
    public GameObject owner;
	private EnemyAI enemyAI;
    private GameObject attackArea;
    public EnemySpawner spawner;

	// Use this for initialization
	void Start () {
        this.currentHealth = startingHealth;
        this.audioSource = GetComponent<AudioSource>();
        this.animator = GetComponent<Animator>();
        this.enemyAI = GetComponent<EnemyAI>();
        this.spawner = GameObject.FindGameObjectsWithTag("Spawner")[0].GetComponent<EnemySpawner>();
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
        else
        {
            this.animator.SetTrigger("hurt");
        }
    }

    public void Death()
    {
        if (!isDead) 
        { 
            this.animator.SetTrigger("dead");
            Destroy(enemyAI);
            Destroy(this.transform.Find("AttackArea").gameObject);
            Destroy(this);
            this.spawner.EnemyDead();
        }
    }
}

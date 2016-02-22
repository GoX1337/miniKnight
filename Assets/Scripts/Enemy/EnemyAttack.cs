using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private Animator animator;
    private AudioSource audioSource;
    public RandomSound randomSwosh;
    public EnemyHealth enemyHealth;
    private float attackDelay;
    public int damagePerAttack = 20;
    public bool missed = true;

	// Use this for initialization
	void Start () {
        this.animator = this.GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();
		this.enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.enemyHealth.isDead)
            return;

        if (Input.GetKey(KeyCode.LeftControl) && this.attackDelay >= 0.3){
            this.attackDelay = 0;
            this.missed = true;
            this.animator.SetTrigger("attack");
        }
        this.attackDelay += Time.deltaTime;
	}

    public void AttackGameObject(GameObject gameObject)
    {
        if (gameObject.GetComponent<EHealth>() != null)
        {
            gameObject.GetComponent<EHealth>().TakeDamage(damagePerAttack);
        }
    }

    public void AttackAnimationEnd()
    {
        if (missed)
        {
            this.audioSource.PlayOneShot(this.randomSwosh.GetRandomSound());
        }
    }
}

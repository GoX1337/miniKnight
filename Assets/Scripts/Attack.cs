using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    private Animator animator;
    private AudioSource audioSource;
    public RandomSound randomSwosh;
    private float attackDelay;
    public int damagePerAttack = 20;
    public bool missed = true;

	// Use this for initialization
	void Start () {
        this.animator = this.GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl) && this.attackDelay >= 0.3){
            this.attackDelay = 0;
            this.missed = true;
            this.animator.SetTrigger("attack");
        }
        this.attackDelay += Time.deltaTime;
	}

    public void AttackGameObject(GameObject gameObject)
    {
        gameObject.GetComponent<Health>().TakeDamage(damagePerAttack);
    }

    public void AttackAnimationEnd()
    {
        if (missed)
        {
            this.audioSource.PlayOneShot(this.randomSwosh.GetRandomSound());
        }
    }
}

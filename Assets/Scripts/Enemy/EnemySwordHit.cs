using UnityEngine;
using System.Collections;

public class EnemySwordHit : MonoBehaviour {

	private EnemyAttack enemyAttack;
    private RandomSound wallHit;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        this.enemyAttack = GetComponentInParent<EnemyAttack>();
        this.wallHit = GetComponent<RandomSound>();
        this.audioSource = GetComponentInParent<AudioSource>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Walls")
        {
            this.enemyAttack.missed = false;
            this.audioSource.PlayOneShot(this.wallHit.GetRandomSound());
        }
        else if (other.name.Contains("Skeleton"))
        {
            this.enemyAttack.missed = false;
            this.enemyAttack.AttackGameObject(other.gameObject);
        }
    }
}

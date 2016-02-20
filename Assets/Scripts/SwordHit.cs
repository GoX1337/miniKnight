using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {

    private Attack attack;
    private RandomSound wallHit;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        this.attack = GetComponentInParent<Attack>();
        this.wallHit = GetComponent<RandomSound>();
        this.audioSource = GetComponentInParent<AudioSource>();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Walls")
        {
            this.attack.missed = false;
            this.audioSource.PlayOneShot(this.wallHit.GetRandomSound());
        }
        else if (other.name.Contains("Skeleton"))
        {
            this.attack.missed = false;
            this.attack.AttackGameObject(other.gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class ShieldBlock : MonoBehaviour {
	
	private Block block;
	private RandomSound wallHit;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		this.block = GetComponentInParent<Block>();
		this.wallHit = GetComponent<RandomSound>();
		this.audioSource = GetComponentInParent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Walls")
		{
			this.block.missed = false;
			this.audioSource.PlayOneShot(this.wallHit.GetRandomSound());
		}
		else if (other.name.Contains("Skeleton"))
		{
			this.block.missed = false;
			this.block.ShieldGameObject(other.gameObject);
		}
	}
}

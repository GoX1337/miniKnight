using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	private Animator animator;
	private AudioSource audioSource;
	public RandomSound shieldMetalSound;
	public PlayerHealth hp;
	public int damagePerAttack = 0;
	public bool missed = true;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator>();
		this.audioSource = GetComponent<AudioSource>();
		hp = GameObject.FindObjectOfType<PlayerHealth> ();
	}

	// Update is called once per frame
	void Update () {
		if (this.hp.isDead)
			return;

		if (Input.GetKey(KeyCode.LeftShift)){
			this.missed = true;
			this.animator.SetTrigger("block");
			Debug.Log ("shield ON");
		}
	}

	public void ShieldGameObject(GameObject gameObject)
	{
		if (gameObject.GetComponent<Health>() != null)
		{
			gameObject.GetComponent<Health>().TakeDamage(damagePerAttack);
		}
	}

	public void ShieldAnimationEnd()
	{
		if (missed)
		{
			this.audioSource.PlayOneShot(this.shieldMetalSound.GetRandomSound());
		}
	
	}
}

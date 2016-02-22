using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : EHealth
{
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

	Animator anim;                                              // Reference to the Animator component.
	AudioSource playerAudio;                                    // Reference to the AudioSource component.
	EnemyMove playerMovement;                              			// Reference to the player's movement.

	public RandomSound painRandomSounds;
	public RandomSound dieRandomSounds;
	public EnemyAttack attack;

	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <EnemyMove> ();
		attack = GetComponent<EnemyAttack>();
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}


	void Update ()
	{
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		// Reset the damaged flag.
		damaged = false;
	}


	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;

		// Reduce the current health by the damage amount.
		currentHealth -= amount;

		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;

		// Play the hurt sound effect.
		this.playerAudio.PlayOneShot(this.painRandomSounds.GetRandomSound());

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
		else
		{
			this.anim.SetTrigger("hurt");
		}
	}

	void Death()
	{
		isDead = true;
		this.playerAudio.PlayOneShot(this.dieRandomSounds.GetRandomSound());
		this.anim.SetTrigger("dead");
	}

	public void SwitchEndGameScene()
	{
		Debug.Log("end...");
		this.GetComponentInParent<EnemyMove>().levelManager.LoadLevel("End");
	}
}
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	private int currentHealth;                   // The current health the enemy has.
    public int scoreValue = 1;


    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
	bool isDead;                                // Whether the enemy is dead.
	bool isSinking;                             // Whether the enemy has started sinking through the floor.
    EnemyHealthBarController healthBar;
    

	void Awake ()
	{
		capsuleCollider = GetComponent <CapsuleCollider> ();

		currentHealth = startingHealth;
        healthBar = GetComponentInChildren<EnemyHealthBarController>();

        
	}

	void Update ()
	{
	}


	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		// If the enemy is dead...
		if(isDead)
			return;

		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;
        healthBar.updateHealthBar((float) currentHealth / (float)startingHealth);



		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;
		Destroy (gameObject);
        ScoreController.score += scoreValue;
	}

}
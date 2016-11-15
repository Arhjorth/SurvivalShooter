using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    private int currentHealth;
    bool isDead;
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.

    PlayerController playerController;
    ShootController shootController; 

    // Use this for initialization
    void Awake () {
        currentHealth = startingHealth;
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerController = GetComponent<PlayerController>();
        shootController = GetComponentInChildren<ShootController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void takeDamage(int amount) {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //enemyAudio.Play ();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // Set the position of the particle system to where the hit was sustained.
        //	Debug.Log(hitParticles.transform.position);
        //	Debug.Log(hitPoint);
        //	hitParticles.transform.position = hitPoint;

        // And play the particles.
        //	hitParticles.Play();

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0) {
            // ... the enemy is dead.
            Death();
        }
    }

    private void Death() {
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        playerController.enabled = false;
        shootController.enabled = false;

        foreach(Renderer r in GetComponentsInChildren<Renderer>()) {
            r.enabled = false;
        }

        GetComponent<Renderer>().enabled = false;

    }
}

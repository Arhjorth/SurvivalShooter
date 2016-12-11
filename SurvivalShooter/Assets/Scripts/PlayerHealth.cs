using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;
    public Slider healthSlider;
    public Image dmgImage;
    public float flashSpeed = 5f;
    public Color flashcolour = new Color(1f, 0f, 0f, 0.1f);
    public bool isDead;
    bool damaged;
    AudioSource deathSound;

    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    PlayerController playerController;
    ShootController shootController;

    // Use this for initialization
    void Awake()
    {
        currentHealth = startingHealth;
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerController = GetComponent<PlayerController>();
        shootController = GetComponentInChildren<ShootController>();
        AudioSource[] sounds =  GetComponents<AudioSource>();
        deathSound = sounds[1];

    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            dmgImage.color = flashcolour;

        }
        else
        {
            dmgImage.color = Color.Lerp(dmgImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void takeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        damaged = true;
        // Play the hurt sound effect.
        //enemyAudio.Play ();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        healthSlider.value = currentHealth;
        // Set the position of the particle system to where the hit was sustained.
        //	Debug.Log(hitParticles.transform.position);
        //	Debug.Log(hitPoint);
        //	hitParticles.transform.position = hitPoint;

        // And play the particles.
        //	hitParticles.Play();

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }

    public void pickupHealth(int amount) {
        currentHealth += amount;
        healthSlider.value = currentHealth;
    }

    private void Death()
    {
        isDead = true;
        deathSound.Play();
        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        playerController.enabled = false;
        shootController.enabled = false;

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }

        GetComponent<Renderer>().enabled = false;
        Application.LoadLevel("Dead");
        DontDestroyOnLoad(deathSound);
    }
}

using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

    private GameObject player;
    PlayerHealth playerHealth;
    public int damage;
    public float timeBetweenAttacks = 0.15f;
    private bool fighting = false;
    float timer;
     
    
	void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();
    }

	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (fighting && timer >= timeBetweenAttacks) {
            playerHealth.takeDamage(damage);
            timer = 0f;
        }
	
	}

    void OnTriggerEnter(Collider other) { // Can only be used when both objects have rigidbodies
        if (other.gameObject.tag == "Player"){
            fighting = true; 
        }
    }
    
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            fighting = false; 
        }
    }
}


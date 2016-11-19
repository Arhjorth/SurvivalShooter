using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {
    public int healthIncrease;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.pickupHealth(healthIncrease);
            Destroy(this.gameObject);
        }
    }
}

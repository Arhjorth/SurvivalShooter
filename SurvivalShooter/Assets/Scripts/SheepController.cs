using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

    Transform playerTransform;
    NavMeshAgent nav;
    private bool playerInRange;
    private bool followPlayer;
    private bool sheepInSafeZone;
    public Plane safeZone;

    void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerInRange = false;
        followPlayer = false;
        sheepInSafeZone = false;
    }

    // Update is called once per frame
    void Update() {
        if (!sheepInSafeZone) { // When sheep is in safe zone, interaction should no longer be possible.


            if (Input.GetKeyDown(KeyCode.F) && playerInRange) {
                if (followPlayer) {
                    followPlayer = false;
                }
                else if (!followPlayer) {
                    followPlayer = true;
                }
            }

            if (followPlayer && playerInRange) {
                nav.SetDestination(playerTransform.position);
            }
        }
        else {
        }    
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    public void setSheepInSafeZone() {
        Debug.Log("SheepController - setSheepInSafeZone");
        sheepInSafeZone = true;
    }
}

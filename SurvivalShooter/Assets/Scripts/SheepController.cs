using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

    Transform playerTransform;
    NavMeshAgent nav;
    private bool playerInRange;
    private bool followPlayer;
    private bool sheepInSafeZone;
    public Plane safeZone;
    AudioSource sheepSound; 
    //int safeZoneMesh;
    void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerInRange = false;
        followPlayer = false;
        sheepInSafeZone = false;
        sheepSound = GetComponent<AudioSource>();
        //safeZoneMesh = NavMesh.GetNavMeshLayerFromName("Safezone");

    }

    // Update is called once per frame
    void Update() {
        if (!sheepInSafeZone) { // When sheep is in safe zone, interaction should no longer be possible.


            if (Input.GetKeyDown(KeyCode.F) && playerInRange) {
                if (followPlayer) {
                    followPlayer = false;
                }
                else if (!followPlayer) {
                    sheepSound.Play();
                    followPlayer = true;
                }
            }

            if (followPlayer && playerInRange) {
                nav.SetDestination(playerTransform.position);
            }
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
        sheepInSafeZone = true;
    }

}

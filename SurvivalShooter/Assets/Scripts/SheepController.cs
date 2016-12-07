using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

    Transform playerTransform;
    NavMeshAgent nav;
    private bool playerInRange;
    private bool followPlayer;

    void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerInRange = false;
        followPlayer = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange ) {
            if (followPlayer) {
                followPlayer = false;
            }
            else if (!followPlayer) {
                followPlayer = true;
            }
        }

        if (followPlayer) {
            nav.SetDestination(playerTransform.position);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("PLAYER IN RANGE");
            playerInRange = true;
        }
    }
}

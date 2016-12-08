using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

    Transform playerTransform;
    NavMeshAgent nav;
    private bool playerInRange;
    private bool followPlayer;
    private bool sheepInSafeZone;
    public Plane safeZone;
    //int safeZoneMesh;
    void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerInRange = false;
        followPlayer = false;
        sheepInSafeZone = false;
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
                    followPlayer = true;
                }
            }

            if (followPlayer && playerInRange) {
                nav.SetDestination(playerTransform.position);
            }
        }
       // else { // Try to get randompoint to work
            //Vector3 rp = RandomPoint(transform.position, 10, safeZoneMesh);
       //     nav.SetDestination(rp);
       // }    
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


    Vector3 RandomPoint(Vector3 center, float range, int meshIndex) {
        Vector3 hitpos = Vector3.zero;
        for (int i = 0; i < 30; i++) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, meshIndex))
                hitpos = hit.position;
         }
        return hitpos;
    }



}

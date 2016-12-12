using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    GameObject player;
    Transform playerTransform;
	NavMeshAgent nav;


	void Awake(){
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
            nav.SetDestination(playerTransform.position);
    }

    public NavMeshAgent getNavMeshAgent() {
        return nav;
    }

    public void setNavMeshAgentSpeed(float newSpeed) {
        nav.speed = newSpeed;

    }
}

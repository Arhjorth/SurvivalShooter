using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
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
}

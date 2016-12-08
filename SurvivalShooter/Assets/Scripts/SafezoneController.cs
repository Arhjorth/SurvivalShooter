using UnityEngine;
using System.Collections;

public class SafezoneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sheep") { // Will only collide with the body collider of the sheep. Tag sheep should be applied on the body.
            other.gameObject.GetComponentInParent<SheepController>().setSheepInSafeZone();
        }
    }

}

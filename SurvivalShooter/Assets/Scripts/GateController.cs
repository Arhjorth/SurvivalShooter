using UnityEngine;
using System.Collections;

public class GateController : MonoBehaviour {

    Transform gateTransform;
    int objectsInCollision = 0;
    Vector3 openPosition;
    Vector3 closedPosition;

	// Use this for initialization
	void Awake () {
        gateTransform = gameObject.transform;
        openPosition = gateTransform.position - new Vector3(0, gateTransform.localScale.y, 0);
        closedPosition = gateTransform.position;

      
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerExit(Collider other) {
        objectsInCollision -= 1;
        Debug.Log("EXIT: " + objectsInCollision);
        if(objectsInCollision == 0) {

            gateTransform.position = closedPosition;

        }
    }

    void OnTriggerEnter(Collider other) {
        objectsInCollision += 1;
        Debug.Log("Enter: " + objectsInCollision);
        if (other.gameObject.tag != "Enemy") {

            gateTransform.position = openPosition;
            
        }
    }
}

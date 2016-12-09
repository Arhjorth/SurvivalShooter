using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {
    public GameObject Pickup;
    GameObject[] spawnPoints;
    float d;

	// Use this for initialization
	void Awake () {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPickup");
	}
	
	// Update is called once per frame
	void Update () {


        d += Time.deltaTime;
        Debug.Log(d);

        if ((int)d == 10) {
            Debug.Log("FUCK YEAH");
            foreach(GameObject pickup in GameObject.FindGameObjectsWithTag("Pickup")) {
                Destroy(pickup);
            }
            GameObject rndSpawn = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
            Instantiate(Pickup, rndSpawn.transform.position, Quaternion.identity);
            d = 0;
        }
	
	}
}

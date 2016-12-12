using UnityEngine;
using System.Collections;

public class SheepSpawner : MonoBehaviour {

    public GameObject Sheep;
    GameObject[] spawnPlaces;
    GameObject safeZone;
    SafezoneController safeZoneInfo;

	// Use this for initialization
	void Awake () {
        spawnPlaces = GameObject.FindGameObjectsWithTag("SpawnSheep");

        safeZone = GameObject.FindGameObjectWithTag("Safezone");
        safeZoneInfo = safeZone.GetComponent<SafezoneController>();
        	
	}
	
	// Update is called once per frame
	void Update () {
        int numberOfSheeps = GameObject.FindGameObjectsWithTag("Sheep").Length;
        int sheepsInPasture = safeZoneInfo.getNumberOfSheeps();
        
        if (numberOfSheeps - sheepsInPasture == 0) {
            GameObject rndSpawn = spawnPlaces[Random.Range(0, spawnPlaces.Length - 1)];
            GameObject instance = (GameObject)Instantiate(Sheep, rndSpawn.transform.position, Quaternion.identity);
        }	
	}
}

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;
    GameObject[] spawnPlaces;
    SafezoneController safeZoneInfo;
    public int numberOfEnemies = 5;
    int startingEnemies;

	// Use this for initialization
	void Start () {
        spawnPlaces = GameObject.FindGameObjectsWithTag("SpawnEnemy");
        safeZoneInfo = GameObject.FindGameObjectWithTag("Safezone").GetComponent<SafezoneController>();
        startingEnemies = numberOfEnemies;

    }

    // Update is called once per frame
    void Update () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        
        if(safeZoneInfo.getNumberOfSheeps() > 0) {
            numberOfEnemies = startingEnemies + safeZoneInfo.getNumberOfSheeps(); 
        }
		if (enemies.Length < numberOfEnemies) {
            GameObject rndSpawn = spawnPlaces[Random.Range(0, spawnPlaces.Length-1)];
			GameObject instance = (GameObject) Instantiate (Enemy, rndSpawn.transform.position, Quaternion.identity);
            if (safeZoneInfo.getNumberOfSheeps() > 0) {
                if (Random.value < safeZoneInfo.getNumberOfSheeps()) {
                    EnemyController ec = instance.GetComponent<EnemyController>();
                    ec.setNavMeshAgentSpeed(ec.getNavMeshAgent().speed + 5); //Hardcoded value

                }
            }
        }
	}
}

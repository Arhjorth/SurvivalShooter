using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;
	private Vector3 offset = new Vector3 (15, 0, 0);
    GameObject[] spawnPlaces;

	// Use this for initialization
	void Start () {
        spawnPlaces = GameObject.FindGameObjectsWithTag("SpawnEnemy");
	}
	
	// Update is called once per frame
	void Update () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        


		if (enemies.Length < 5) {
            GameObject rndSpawn = spawnPlaces[Random.Range(0, spawnPlaces.Length-1)];
			Instantiate (Enemy, rndSpawn.transform.position, Quaternion.identity);
		}
	}
}

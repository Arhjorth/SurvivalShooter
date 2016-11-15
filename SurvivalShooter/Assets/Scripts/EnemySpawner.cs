using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;
	private Vector3 offset = new Vector3 (15, 0, 0);

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			Instantiate (Enemy, this.transform.position+offset, Quaternion.identity);
		}

			
	}
	
	// Update is called once per frame
	void Update () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (enemies.Length < 5) {
			Instantiate (Enemy, this.transform.position+offset, Quaternion.identity);
		}
	}
}

using UnityEngine;
using System.Collections;
using System;

public class EnemyHealthBarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void updateHealthBar(float newScale) {
        this.transform.localScale = new Vector3(newScale, this.transform.localScale.y, this.transform.localScale.z);
    }
}

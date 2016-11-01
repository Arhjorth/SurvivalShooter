﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody rgb;
	public int speed;
	public float rotationSpeed;
	Vector3 movement;
	Plane playerPlane;


	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.D)) {
//			movement = new Vector3 (-speed, 0, 0);
//		} else if (Input.GetKeyDown (KeyCode.A)) {
//			movement = new Vector3 (speed, 0, 0);
//		} else if (Input.GetKeyDown (KeyCode.W)) {
//			movement = new Vector3 (0, 0, speed);
//		} else if (Input.GetKeyDown (KeyCode.S)) {
//			movement = new Vector3 (0, 0, -speed);
//		} else {
//			movement = new Vector3 (0, 0, 0);
//		}
			
	
	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw("Horizontal"); // Will only have the values -1, 0 or 1
		float v = Input.GetAxisRaw("Vertical");

		move (h, v);
		Turn ();
	}

	void move(float h, float v) {
		movement.Set(h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		rgb.MovePosition(transform.position + movement);
	}
		
	void Turn() {
		playerPlane = new Plane (Vector3.up, transform.position);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		float hitdist = 0f;

		if (playerPlane.Raycast(ray,out hitdist)) {
			Vector3 targetPoint = ray.GetPoint(hitdist);

			Quaternion targetRotation = Quaternion.LookRotation(targetPoint-transform.position);


		}
	}

}

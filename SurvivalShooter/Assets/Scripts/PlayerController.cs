using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody rgb;
	public int speed;
	Vector3 movement;
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
	}

	void move(float h, float v) {
		movement.Set(h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		rgb.MovePosition(transform.position + movement);
	}
		
}

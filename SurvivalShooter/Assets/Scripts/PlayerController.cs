using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
	Rigidbody rgb;
	public int speed;
    //	public float rotationSpeed;
    public Slider staminaSlider;
	Vector3 movement;
	bool sprint = false;
    AudioSource playerSound;

//	Plane playerPlane;

//	private Vector3 worldpos;
//	private float mouseX;
//	private float mouseY;
//	private float cameraDif;
	float camRayLength = 200f;

//	public GameObject fpc;

	int floorMask;
    private int stamina;

    void Awake(){
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");
		rgb = GetComponent<Rigidbody> ();
        stamina = 100;
        playerSound = GetComponent<AudioSource>();

	}

	// Use this for initialization
//	void Start () {
//		cameraDif = GetComponent<Camera>().transform.position.y - fpc.transform.position.y;




	
//	}


	
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

		if (Input.GetButton("LeftShift") && stamina >= 6) {
			sprint = true;
		} else{
			sprint = false;
		}
			
	
	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw("Horizontal"); // Will only have the values -1, 0 or 1
		float v = Input.GetAxisRaw("Vertical");

		move (h, v, sprint);
		Turning ();
	}

	void move(float h, float v, bool sprint) {
		movement.Set(h, 0f, v);

		if (sprint) {
			movement = movement.normalized * 2 * speed * Time.deltaTime;
            stamina -= 6;
            staminaSlider.value = stamina;
            if (!playerSound.isPlaying) {
                playerSound.pitch = 1f;
                playerSound.Play();
            }else if(playerSound.isPlaying && playerSound.pitch == 0.5f) {
                playerSound.Stop();
                playerSound.pitch = 1;
                playerSound.Play();
            }
		} else if(!sprint) {
			movement = movement.normalized * speed * Time.deltaTime;
            staminaSlider.value = stamina;

            if (playerSound.isPlaying && playerSound.pitch == 1f) {
                playerSound.Stop();
                playerSound.pitch = 0.5f;
                playerSound.Play();
            } else if (!playerSound.isPlaying && (h != 0f || v != 0f)) {
                playerSound.pitch = 0.5f;
                playerSound.Play();
            }else if(playerSound.isPlaying && (h == 0f && v == 0f)) {
                playerSound.Stop();
            }
            
            
            if (!Input.GetButton("LeftShift")) { stamina += 3; }
        }
        else { playerSound.Stop(); }

		rgb.MovePosition(transform.position + movement);
	}

	void Turning ()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;

		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;

			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;

			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

			// Set the player's rotation to this new rotation.
			rgb.MoveRotation (newRotation);
		}
	}


//	void Turn() {
//		playerPlane = new Plane (Vector3.up, transform.position);
//
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//
//		float hitdist = 0f;
//
//		if (playerPlane.Raycast(ray,out hitdist)) {
//			Vector3 targetPoint = ray.GetPoint(hitdist);
//
//			Quaternion targetRotation = Quaternion.LookRotation(targetPoint-transform.position);
//
//
//		}
//	}
//



//	void LookAtMouse()
//	{
//		mouseX = Input.mousePosition.x;
//
//		mouseY = Input.mousePosition.y;
//
//		worldpos = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));
//
//		Vector3 turretLookDirection = new Vector3 (worldpos.x,fpc.transform.position.y, worldpos.z);
//
//		fpc.transform.LookAt(turretLookDirection);
//	}

		
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
	Rigidbody rgb;
	public int speed;
    public Slider staminaSlider;

	Vector3 movement;
	bool sprint = false;
    AudioSource playerSound;

	float camRayLength = 400f;


	int floorMask;
    private int stamina;

    void Awake(){

        floorMask = LayerMask.GetMask ("Floor");
		rgb = GetComponent<Rigidbody> ();
        stamina = 100;
        playerSound = GetComponent<AudioSource>();

	}

	void Update () {


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
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

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
		
}

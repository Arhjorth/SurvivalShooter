using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {

    Transform playerTransform;
    NavMeshAgent nav;
    private bool playerInRange;
    private bool followPlayer;
    private bool sheepInSafeZone;
    public Plane safeZone;

    string messageMid;
    string messageRight;
    bool displayTextMid;
    bool displayTextRight;
    bool timer;
    float counter;


    //int safeZoneMesh;
    void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerInRange = false;
        followPlayer = false;
        sheepInSafeZone = false;
        //safeZoneMesh = NavMesh.GetNavMeshLayerFromName("Safezone");

    }

    // Update is called once per frame
    void Update() {

        if (timer)
        {
            counter += Time.deltaTime;
        }
        if (counter > 3)
        {
            displayTextMid = false;
            displayTextRight = false;
            timer = false;
            counter = 0;
        }


        if (!sheepInSafeZone) { // When sheep is in safe zone, interaction should no longer be possible.


            if (Input.GetKeyDown(KeyCode.F) && playerInRange) {
                if (followPlayer) {
                    followPlayer = false;
                   
                }
                else if (!followPlayer) {
                    followPlayer = true;
                    messageMid = "The sheep is now following you";
                    displayTextMid = true;
                }
            }

            if (followPlayer && playerInRange) {
                nav.SetDestination(playerTransform.position);
                messageMid = "The sheep is now following you";
                displayTextMid = true;
            }
        }
       // else { // Try to get randompoint to work
            //Vector3 rp = RandomPoint(transform.position, 10, safeZoneMesh);
       //     nav.SetDestination(rp);
       // }    
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            playerInRange = false;
            
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            playerInRange = true;
            messageRight = "press 'f' to make the sheep follow you";
            displayTextRight = true;
        }
    }

    public void setSheepInSafeZone() {
        sheepInSafeZone = true;
    }


    Vector3 RandomPoint(Vector3 center, float range, int meshIndex) {
        Vector3 hitpos = Vector3.zero;
        for (int i = 0; i < 30; i++) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, meshIndex))
                hitpos = hit.position;
         }
        return hitpos;
    }
    void OnGUI()
    {

        if (displayTextMid)
        {
            timer = true;
            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 4 - 25, 100, 50), messageMid, centeredStyle);
        }

        if (displayTextRight)
        {
            timer = true;
            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(Screen.width - 110, Screen.height / 4 - 100, 100, 50), messageRight, centeredStyle);
        }
    }


}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SafezoneController : MonoBehaviour {

    public int pointsToUpgrade;
    string messageMid;
    string messageRight;
    bool displayTextMid;
    bool displayTextRight;
    bool timer;
    float counter;
    int fenceSize;
    int sheeps;
    int reqSheepsToWinLvl01;
    int reqSheepsToWinLvl02;
    GateController[] gates;
    AudioSource sheepInPasture;

    public int test;

	// Use this for initialization
	void Awake () {
        reqSheepsToWinLvl01 = 1;
        reqSheepsToWinLvl02 = 1;
        gates = GetComponentsInChildren<GateController>();
        sheepInPasture = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        
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


        if (Input.GetKeyDown(KeyCode.U))
        {
            //if (fenceSize == 0)
            //{
            //    foreach (Transform child in transform)
            //    {
            //        child.gameObject.SetActive(true);
            //    }
            //    messageMid = "Fence upgraded";
            //    fenceSize = 1;
            //}

            if (SceneManager.GetActiveScene().buildIndex != 1)
            {

                if (fenceSize == 0 && ScoreController.score >= pointsToUpgrade)
                {
                    transform.localScale = new Vector3(7f, transform.localScale.y, 7f);
                    resizeGateController();
                    fenceSize = 1;
                    messageMid = "Fence upgraded";
                }
                else if (fenceSize == 1 && ScoreController.score >= pointsToUpgrade * 2)
                {
                    transform.localScale = new Vector3(10f, transform.localScale.y, 10f);
                    resizeGateController();
                    fenceSize = 2;
                    messageMid = "Fence upgraded";
                }
                else if (fenceSize == 2)
                {
                    messageMid = "Fence is fully upgraded";
                }
                else
                {
                    messageMid = "Not Enough points to upgrade";
                }
                displayTextMid = true;
            }
        }

        //if (SceneManager.GetActiveScene().buildIndex == 0){
        //    test = 1;
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    test = 2;
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    test = 3;
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == 3)
        //{
        //    test = 4;
        //}


        if (SceneManager.GetActiveScene().buildIndex == 1 && reqSheepsToWinLvl01 == sheeps)
        {
            SceneManager.LoadScene("lvl02");
            sheeps = 0;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 && reqSheepsToWinLvl02 == sheeps)
        {
            SceneManager.LoadScene("lvl03");
            sheeps = 0;
        }

    }

    public int getNumberOfSheeps() {
        return sheeps;
    }
	
    void resizeGateController() {
        foreach(GateController gateC in gates) {
            gateC.setSize();
        }
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

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sheep") { // Will only collide with the body collider of the sheep. Tag sheep should be applied on the body.
            other.gameObject.GetComponentInParent<SheepController>().setSheepInSafeZone();
            sheeps += 1;
            sheepInPasture.Play();
        }
        if (other.gameObject.tag == "Player" && SceneManager.GetActiveScene().buildIndex != 1)
        {
            messageRight = "Press 'U' to upgrade the fence";
            displayTextRight = true;
        }
    }

}

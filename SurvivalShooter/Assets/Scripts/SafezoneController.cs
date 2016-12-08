using UnityEngine;
using System.Collections;

public class SafezoneController : MonoBehaviour {

    public int pointsToUpgrade;
    string message;
    bool displayTextMid;
    bool displayTextRight;
    bool timer;
    float counter;
    int fenceSize;
    int posWidth;
    int posHeight;


	// Use this for initialization
	void Start () {
	
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
            if (fenceSize == 0 && ScoreController.score >= pointsToUpgrade)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                message = "Fence upgraded";
                fenceSize = 1;
            }

            else if (fenceSize == 1 && ScoreController.score >= pointsToUpgrade * 2)
            {
                transform.localScale = new Vector3(7f, transform.localScale.y, 7f);
                fenceSize = 2;
                message = "Fence upgraded";
            }
            else if (fenceSize == 2 && ScoreController.score >= pointsToUpgrade * 4)
            {
                transform.localScale = new Vector3(10f, transform.localScale.y, 10f);
                fenceSize = 3;
                message = "Fence upgraded";
            }
            else if (fenceSize == 3)
            {
                message = "Fence is fully upgraded";
            }
            else
            {
                message = "Not Enough points to upgrade";
            }
            displayTextMid = true;
        }

    }
	

    void OnGUI()
    {
        if (displayTextMid)
        {
            posWidth = Screen.width / 2 - 50;
            posHeight = Screen.height / 4 - 25;
        }

        if (displayTextRight)
        {
            posWidth = Screen.width - 110;
            posHeight = Screen.height / 4 - 100;
        }


        if (displayTextMid || displayTextRight)
        {
            timer = true;
            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(posWidth, posHeight, 100, 50), message, centeredStyle);
        }



    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sheep") { // Will only collide with the body collider of the sheep. Tag sheep should be applied on the body.
            other.gameObject.GetComponentInParent<SheepController>().setSheepInSafeZone();
        }
        if (other.gameObject.tag == "Player")
        {
            message = "Press 'U' to upgrade the fence";
            displayTextRight = true;
        }
    }

}

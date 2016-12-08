using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour {

    public int pointsToUpgrade;
    string message = "Not enough points";
    bool NotEnoughPoints;
    bool timer;
    float counter;


	// Use this for initialization
    void Awake()
    {
        
    }
	
	// Update is called once per frame
    void Update()
    {
        if (timer)
        {
            counter += Time.deltaTime;
        }
        if (counter > 3)
        {
            NotEnoughPoints = false;
            timer = false;
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            if (ScoreController.score >= pointsToUpgrade)
            {
                foreach (Transform child in transform)

                    child.gameObject.SetActive(true);
            }
            else
            {
                NotEnoughPoints = true;

            }
        }
    }
    void OnGUI()
    {
        if (NotEnoughPoints)
        {
            timer = true;
            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 4 - 25, 100, 50), message, centeredStyle);
        }
    }
}

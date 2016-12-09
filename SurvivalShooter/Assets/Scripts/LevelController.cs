using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
    
    public int reqSheepsToWin;
    public int level;
    public int sheeps;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (sheeps == reqSheepsToWin)
        {
            Application.LoadLevel("Lvl02");
        }
	
	}
    public void addSheep()
    {
        sheeps += 1;
    }
}

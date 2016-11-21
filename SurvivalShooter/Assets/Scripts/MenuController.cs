using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject menu;
    
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player").GetComponent<PlayerHealth>().isDead)
        {
        menu.SetActive(true);
    }
        else menu.SetActive(false);
	}
}

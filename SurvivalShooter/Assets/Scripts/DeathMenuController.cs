using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour {
    GameObject DeathMenu;
    PlayerHealth PlayerHealth;
    Scene currentScene;

	// Use this for initialization
	void Start () {
	DeathMenu = GameObject.Find("DeathMenu");
    PlayerHealth = GetComponent<PlayerHealth>();
    currentScene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerHealth.GetIsDead())
        {
            DeathMenu.SetActive(true);
        }

        if (!PlayerHealth.GetIsDead()){ 
            DeathMenu.SetActive(false); 
        }
	}

    public void PlayAgain()
    {
        //SceneManager.LoadScene("currentScene");
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        PlayerHealth.setIsdead(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}

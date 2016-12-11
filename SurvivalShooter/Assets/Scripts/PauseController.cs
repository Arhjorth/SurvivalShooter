using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    GameObject PauseMenu;
    bool paused;


    void Start()
    {
        paused = false;
        PauseMenu = GameObject.Find("PauseMenu");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;

        }
        else if (!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        paused = false;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    
    public void Quit()
    {

        Application.Quit();
    }
}

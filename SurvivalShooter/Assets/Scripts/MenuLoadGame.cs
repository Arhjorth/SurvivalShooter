using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuLoadGame : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("lvl00");
    }


}

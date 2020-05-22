using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextLevelandExit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level0");
    }
    public void Demo()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

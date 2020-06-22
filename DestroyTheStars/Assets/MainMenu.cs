using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   
    
   
    public void PlayGame()
    {
        SceneManager.LoadScene("difficulty");
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
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void clickHighScore()
    {
        //Debug.Log(GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text.ToString());
        
        if (GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text.ToString().Equals(PlayerCtrl.bananaScore.ToString()))
        {
            
            GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text = "High Score";
        }
        else
        {
            GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text = PlayerCtrl.bananaScore.ToString();
        }
        
        
    }
}

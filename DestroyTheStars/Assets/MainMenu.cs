using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    name theName;
   
    public void PlayGame()//go level  0
    {
        SceneManager.LoadScene("level0");
    }
    public void Demo()//go level 1
    {
        SceneManager.LoadScene("Level1");
    }


    public void QuitGame()//quit game
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void menu()//go menu
    {
        SceneManager.LoadScene("Menu");
    }
    public void character()//go characters scene
    {
        SceneManager.LoadScene("characters");
    }
    public void level()//go difficulity scene
    {
        SceneManager.LoadScene("difficulty");
    }
    public void clickHighScore()//when click high score button
    {
        //Debug.Log(GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text.ToString());

        if (GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text.ToString().Equals(PlayerCtrl.bananaScore.ToString()))
        {

            GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text = "High Score";
        }
        else
        {
      
            GameObject.Find("HighScore").GetComponentInChildren<TextMeshProUGUI>().text=PlayerPrefs.GetString("tytiruakText") +": "+ PlayerCtrl.bananaScore.ToString();
        }
        
        
    }
}

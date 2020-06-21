using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]
public class GameCtrl : MonoBehaviour
{
    public static GameCtrl inst;

    public GameObject endUI;
    public Text scoreLabel;
    
    public int score = 0;
    public string nextScene;
    private PropCtrl[] propCtrls;
    public Text healthLabel;
    public static int timeScore;
    public static int timeScore1;
    public static int timeScore2;
    //public countdownTimer ct;


    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        propCtrls = GameObject.FindObjectsOfType<PropCtrl>();
    }
    public  void high_Score()
    {
        Debug.Log(SceneManager.GetActiveScene().name.Equals("level0"));
        if (SceneManager.GetActiveScene().name.Equals("level0"))
        {
            if (score == 3)
            {
                timeScore = (int)(60 - countdownTimer.currentTime);
                Debug.Log("asdasdas" + timeScore);
                return;
            }
           
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level4"))
        {
            if (score < propCtrls.Length) return;
            timeScore1 = (int)(60 - countdownTimer.currentTime);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level5"))
        {
            if (score < propCtrls.Length) return;
            timeScore2 = (int)(60 - countdownTimer.currentTime);
        }
    }
    public void JudgeSuccess()
    {
        score++;
        scoreLabel.text = score.ToString();
        if (score < propCtrls.Length) return;
        
       
        LoadScene(nextScene);
    }
    
    public void heal()
    {

        healthLabel.text = PlayerCtrl.pc.healthPoint.ToString();
        Debug.Log("jiaxie");
    }
    public void OnFailed()
    {
        endUI.SetActive(true);
    }

    public void LoadScene(string _name)
    {
        SceneManager.LoadScene(_name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

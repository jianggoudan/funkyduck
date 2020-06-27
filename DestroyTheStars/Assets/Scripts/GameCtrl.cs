
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
    public Text bananaLabel;



    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        propCtrls = GameObject.FindObjectsOfType<PropCtrl>();
    }

    public void JudgeSuccess()//add stars, go to next scene if collect 3 stars
    {
        score++;
        scoreLabel.text = score.ToString();
        if (score < propCtrls.Length) return;

        LoadScene(nextScene);
    }

    public void heal()//collect battery
    {

        healthLabel.text = PlayerCtrl.healthPoint.ToString();
       
    }
    public void addBanana()//collect bananas
    {
       bananaLabel.text = PlayerCtrl.bananaScore.ToString();
    }
    public void OnFailed()//die
    {
        endUI.SetActive(true);
    }

    public void LoadScene(string _name)//load scene
    {
        SceneManager.LoadScene(_name);
    }
    public void Quit()//exit
    {
        Application.Quit();
    }
}

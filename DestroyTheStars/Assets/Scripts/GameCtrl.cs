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
    
    
    

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        propCtrls = GameObject.FindObjectsOfType<PropCtrl>();
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

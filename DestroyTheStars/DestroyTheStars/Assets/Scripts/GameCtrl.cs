using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameCtrl : MonoBehaviour
{
    public static GameCtrl inst;

    public GameObject endUI;
    public Text scoreLabel;
    public string nextScene;

    private PropCtrl[] propCtrls;
    private int score = 0;
    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        propCtrls = GameObject.FindObjectsOfType<PropCtrl>();
    }

    public  void  JudgeSuccess()
    {
        score++;
        scoreLabel.text = score.ToString();
        if (score < propCtrls.Length) return;

        LoadScene(nextScene);
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

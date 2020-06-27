using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //the ButtonPauseMenu
    public GameObject ingameMenu;

    public void OnPause()//when click pause
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }

    public void OnResume()//when click resume
    {
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }

    public void OnRestart()//when click restart
    {
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }

}

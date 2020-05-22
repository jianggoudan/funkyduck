using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextLevelandExit()
    {
        SceneManager.LoadScene("Menu");
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class difficultySelector : MonoBehaviour
{
    // Start is called before the first frame update
    public void hard()
    {
        SceneManager.LoadScene("Level5");
    }
    public void medium()
    {
        SceneManager.LoadScene("Level4");
    }

    public void easy()
    {
        SceneManager.LoadScene("Level0");
    }
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }
}

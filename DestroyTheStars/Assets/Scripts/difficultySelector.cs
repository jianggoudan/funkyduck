using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class difficultySelector : MonoBehaviour
{
    // Start is called before the first frame update
    public void hard()//select hard level
    {
        SceneManager.LoadScene("Level5");
    }
    public void medium()//select medium level
    {
        SceneManager.LoadScene("Level4");
    }

    public void easy()//select easy level
    {
        SceneManager.LoadScene("Level0");
    }
    public void back()//back to the menu
    {
        SceneManager.LoadScene("Menu");
    }
}

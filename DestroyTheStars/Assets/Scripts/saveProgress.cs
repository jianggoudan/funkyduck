using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// save progress, but it does not work.
public class saveProgress : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameCtrl data;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            PlayerPrefs.SetString("current level", SceneManager.GetActiveScene().ToString());
            PlayerPrefs.SetInt("score", data.score);
            Debug.Log("SAVE");
        }
        if(Input.GetKey(KeyCode.X))
        {
            Scene s = new Scene();
          //  s.name = PlayerPrefs.GetString("current Level");
           // SceneManager.SetActiveScene(s);
            data.score = PlayerPrefs.GetInt("score");
            Debug.Log("LOAD");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class name : MonoBehaviour
{
    
    public  string tytiruakText;
    public InputField inputText;
    

    // Start is called before the first frame update
   public void saveThis()//save name
    {
        tytiruakText = inputText.text;
        PlayerPrefs.SetString("tytiruakText", tytiruakText);
        Debug.Log(tytiruakText);
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_script : MonoBehaviour
{
    public GameObject avatar1;
    public GameObject avatar2;
    private Vector3 CharacterPosition;
    private Vector3 offScreen;
    private int CharacterInt = 1;
    private SpriteRenderer avatar1Render, avatar2Render;
    private readonly string selectedCharacter = "SelectedCharacter";
    private void Awake()
    {
        CharacterPosition = avatar1.transform.position;
        offScreen = avatar2.transform.position;
        avatar1Render = avatar1.GetComponent<SpriteRenderer>();
        avatar2Render = avatar2.GetComponent<SpriteRenderer>();
    }
    public void NextCharacter()
    {
        switch(CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                avatar1Render.enabled = false;
                avatar1.transform.position = offScreen;
                avatar2.transform.position = CharacterPosition;
                avatar2Render.enabled = true;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                avatar2Render.enabled = false;
                avatar2.transform.position = offScreen;
                avatar1.transform.position = CharacterPosition;
                avatar1Render.enabled = true;
                CharacterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }
    public void PreviousCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                avatar1Render.enabled = false;
                avatar1.transform.position = offScreen;
                avatar2.transform.position = CharacterPosition;
                avatar2Render.enabled = true;
                CharacterInt--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                avatar2Render.enabled = false;
                avatar2.transform.position = offScreen;
                avatar1.transform.position = CharacterPosition;
                avatar1Render.enabled = true;
                CharacterInt--;
                break;
            default:
                ResetInt();
                break;
        }
    }
    private void ResetInt()
    {
        if(CharacterInt>=2)
        {
            CharacterInt = 1;
        }
        else
        {
            CharacterInt = 2;
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("level0");
    }
}

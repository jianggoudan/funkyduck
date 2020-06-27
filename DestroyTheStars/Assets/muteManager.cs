using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteManager : MonoBehaviour
{
	private bool isMuted;

    void Start()
    {
		isMuted = false;
    }

    public void MutePressed()//click mute button, if it is mute, display sound, or mute
	{
		isMuted = !isMuted;
	    AudioListener.pause = isMuted;
	}

}

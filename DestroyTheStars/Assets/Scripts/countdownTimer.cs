﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownTimer : MonoBehaviour
{
    public  static float currentTime = 0f;
  
    public static float startingTime = 60f;
    
    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    //decrease time 60 seconds to 0;
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        if (currentTime < 10)
        {
            countdownText.color = Color.red;
        }
        if(currentTime==0)
         {
             PlayerCtrl.pc.healthPointZero();
         }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanagere : MonoBehaviour
{
    public static UImanagere instance { get; private set; }
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
   public void UpdateHealthBar()
    {
       // healthBar.fillAmount = 0.0f;
    }
}

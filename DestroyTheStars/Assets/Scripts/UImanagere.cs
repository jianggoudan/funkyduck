using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//we tried to manage UI more efficiently, but not work
public class UImanagere : MonoBehaviour
{
    public static UImanagere instance { get; private set; }
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}

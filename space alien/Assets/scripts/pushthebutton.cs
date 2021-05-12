using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class pushthebutton : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };
    private int deviderposition;
    private string buttonname, buttonvalue;
    // Start is called before the first frame update
    void Start()
    {
        buttonname = gameObject.name;
        deviderposition = buttonname.IndexOf("_");
        buttonvalue = buttonname.Substring(0, deviderposition);
        gameObject.GetComponent<Button>().onClick.AddListener(buttonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void buttonClicked()
    {
        ButtonPressed(buttonvalue);
    }
}

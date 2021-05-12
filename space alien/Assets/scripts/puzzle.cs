using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public GameObject ObjectToDisable;
    public GameObject ObjectToEnable;
    public GameObject uiObject;
    public bool canuse;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canuse == true)
        {
           
            ObjectToDisable.SetActive(false);
            ObjectToEnable.SetActive(true);
        }
        /*  if (keypadScreen)
          {
              ObjectToDisable.SetActive(false);
              ObjectToEnable.SetActive(true);
          }*/
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            canuse = true;

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
            canuse = false;

        }
    }
}

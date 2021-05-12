using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatingcrew : MonoBehaviour
{
    public bool caneat;
    public GameObject uiObject;
    public GameObject Enemy;
    
 
    
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && caneat == true)
        {
            Enemy.SetActive(false);
          //  GameObject.Find("player").GetComponent<AudioSource>();
            
        }
    }


    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            caneat = true;



        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
            caneat = false;

        }
    }
}

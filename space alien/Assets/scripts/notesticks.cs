using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notesticks : MonoBehaviour { 
 public GameObject uiObject;
public GameObject uicard;
public bool cancheck;
    public bool cardseen;

void Start()
{
    uiObject.SetActive(false);
        uicard.SetActive(false);
        
}
void Update()
{
    if (Input.GetKeyDown(KeyCode.Q) && cancheck == true)
        { 
            checking();
    }
     else if (Input.GetKeyDown(KeyCode.Q) && cardseen == true)
        {
            unchecking();
        }
}
private void OnTriggerEnter2D(Collider2D other)

{
    if (other.gameObject.tag == "Player")
    {
        uiObject.SetActive(true);
        cancheck = true;
    }
}
private void OnTriggerExit2D(Collider2D other)
{
    if (other.gameObject.tag == "Player")
    {
        uiObject.SetActive(false);
        cancheck = false;

    }
}
    private void checking()
    {
        uicard.SetActive(true);
        uiObject.SetActive(false);
        cardseen = true;
    }
    private void unchecking()
    {
        uicard.SetActive(false);
        uiObject.SetActive(true);
        cardseen = false;
    }
    }

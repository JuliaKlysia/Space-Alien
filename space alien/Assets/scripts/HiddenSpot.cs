using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpot : MonoBehaviour
{ 
    public GameObject uiObject;
    public Sprite AlienInside;
    private Sprite AlienOutside;
    public GameObject Light;
    private bool touchingCollider;
    private bool isHidden;
    private GameObject player;

    private SpriteRenderer sprRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        isHidden = false;
        touchingCollider = false;

        sprRenderer = this.GetComponent<SpriteRenderer>();
        AlienOutside = sprRenderer.sprite;

        uiObject.SetActive(false);
        Light.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
   
   {
      if (other.gameObject.tag == "Player")
      {
            uiObject.SetActive(true);
            Light.SetActive(true);
            touchingCollider = true;
            Debug.Log("trigger enter");
            Debug.Log(gameObject.name);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
            Light.SetActive(false);
            touchingCollider = false;
            Debug.Log("Trigger exit");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingCollider == true && !isHidden)
        {
            hide();

        }
        else if (Input.GetKeyDown(KeyCode.E) && touchingCollider == false && isHidden)
        {
            unhide();
        }
    }
    void hide()
   {
        player.SetActive(false);
        Debug.Log("just got in");
        isHidden = true;
        sprRenderer.sprite = AlienInside;    
   }

    void unhide()
    {
        player.SetActive(true);
        Debug.Log("exited now");
        isHidden = false;
        sprRenderer.sprite = AlienOutside;
    }
    

}

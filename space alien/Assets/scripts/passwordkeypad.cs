using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class passwordkeypad : MonoBehaviour
{
    [Header("Objects to hide/show")]
    public GameObject ObjectToDisable;
    public GameObject ObjectToEnable;
    [Header("keypad settings")]
    public string curPassowrd = "1510";
    public string input;
    public Text displayText;


    private bool keypadScreen;
    private float btnclicked = 0;
    private float numofguesses;

    public GameObject beds;

    public GameObject uiObject;
    public bool canuse;
    public AudioClip impact;
    public AudioClip notimpact;
    AudioSource audioSource;

    GameObject[] bedArray;

    private GameObject progressManager;

    private void Start()
    {
        btnclicked = 0;
        numofguesses = curPassowrd.Length;
        audioSource = GetComponent<AudioSource>();

        bedArray = GameObject.FindGameObjectsWithTag("bed");

        progressManager = GameObject.Find("ProgressManager");

    }
    private void Update()
    {
        if (btnclicked == numofguesses)
        {
            if (input == curPassowrd)
            {
                Debug.Log("correct password");
                input = "";
                btnclicked = 0;
                ObjectToDisable.SetActive(true);
                ObjectToEnable.SetActive(false);
                progressManager.GetComponent<ProgressTracker>().isCrewQuartersComplete = true;
                //GameObject.Find("door").GetComponent<CorridorPortal>().enabled = true;    Deprecated
                GameObject.Find("ProgressManager").SendMessage("UpdatePortalAccess");

                foreach (GameObject bed in bedArray)
                {
                    bed.SendMessage("ChangeBed", true);
                }


                Destroy(this);


            }
            else
            {
                input = "";
                displayText.text = input.ToString();
                btnclicked = 0;
                audioSource.PlayOneShot(impact, 1.5f);

            }
        }

    }

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canuse == true)
        {
           
        
            ObjectToDisable.SetActive(false);
            ObjectToEnable.SetActive(true);
        }
        if (keypadScreen)
        {
            ObjectToDisable.SetActive(false);
            ObjectToEnable.SetActive(true);
        }
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
        
    
    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": //quit
                ObjectToDisable.SetActive(true);
                ObjectToEnable.SetActive(false);
                btnclicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                audioSource.PlayOneShot(impact, 1.5f);
                break;
            case "C":
                input = "";
                btnclicked = 0;
                displayText.text = input.ToString();
                audioSource.PlayOneShot(impact, 1.5f);
                break;
            default:
                btnclicked++;
                input += valueEntered;
                displayText.text = input.ToString();
                audioSource.PlayOneShot(notimpact, 0.7f);
                break;



        }
    }
}

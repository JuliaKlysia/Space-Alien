using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzzle : MonoBehaviour
{
    private int successCounter;
    public GameObject puzzleCanvas;
    public GameObject puzzleCanvas_2;
    private GameObject player;
    private int puzzlesCompleted;
    public AudioClip impact;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        successCounter = 0;
        puzzlesCompleted = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (successCounter == 3)
        {
            //win situation
            Debug.Log("You won , can do stuff");
            if (puzzleCanvas.active)
            {
                puzzleCanvas.SetActive(false);
                GameObject.Find("puzzlebox").SetActive(false);
                GameObject.Find("water fountain").SendMessage("UpdateFountain", 1);
                puzzlesCompleted++;
                audioSource.PlayOneShot(impact, 0.7f);
            }
            else
            {
                puzzleCanvas_2.SetActive(false);
                GameObject.Find("puzzlebox 2").SetActive(false);
                GameObject.Find("water fountain").SendMessage("UpdateFountain", 1);
                puzzlesCompleted++;
                audioSource.PlayOneShot(impact, 0.7f);
            }
            
            player.SetActive(true);
            successCounter = 0;

            if(puzzlesCompleted == 2)
            {
                //GameObject.Find("door").GetComponent<CorridorPortal>().enabled = true;  DEPRECATED
                GameObject.Find("ProgressManager").GetComponent<ProgressTracker>().isGreenHouseComplete = true;
                GameObject.Find("ProgressManager").GetComponent<LevelProgress>().isCorridorPortalOpen = true;
            }
        }
    }

    private void UpdatePuzzle(int successCount)
    {
        Debug.Log("One success");   
        successCounter += successCount;
    }
}

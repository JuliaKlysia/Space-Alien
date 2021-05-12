using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProgress : MonoBehaviour
{

   
    public Color changeCircleColor;
    public GameObject[] circles;

    private GameObject progressManager;

    public string leveltoload;
    // Start is called before the first frame update
    void Start()
    {
        progressManager = GameObject.Find("ProgressManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (progressManager.GetComponent<ProgressTracker>().isGreenHouseComplete)
        {
            circles[0].GetComponent<SpriteRenderer>().color = changeCircleColor;
        }
        if (progressManager.GetComponent<ProgressTracker>().isStorageComplete)
        {
            circles[1].GetComponent<SpriteRenderer>().color = changeCircleColor;
        }
        if (progressManager.GetComponent<ProgressTracker>().isCrewQuartersComplete)
        {
            circles[2].GetComponent<SpriteRenderer>().color = changeCircleColor;
        }
        if (progressManager.GetComponent<ProgressTracker>().isGreenHouseComplete && progressManager.GetComponent<ProgressTracker>().isStorageComplete && progressManager.GetComponent<ProgressTracker>().isCrewQuartersComplete)
        {
            Application.LoadLevel(leveltoload);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalSpawning : MonoBehaviour
{
    private GameObject progressManager;
    
    // Start is called before the first frame update
    void Start()
    {
        progressManager = GameObject.Find("ProgressManager");
        switch (progressManager.GetComponent<ProgressTracker>().teleportStatusCode)
        {
            case 1:
                transform.position = progressManager.GetComponent<ProgressTracker>().crewCabinSpawn.position;
                progressManager.GetComponent<ProgressTracker>().teleportStatusCode = 0;
                break;
            case 2:
                transform.position = progressManager.GetComponent<ProgressTracker>().storagePortalSpawn.position;
                progressManager.GetComponent<ProgressTracker>().teleportStatusCode = 0;
                break;
            case 3:
                transform.position = progressManager.GetComponent<ProgressTracker>().greenHousePortalSpawn.position;
                progressManager.GetComponent<ProgressTracker>().teleportStatusCode = 0;
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

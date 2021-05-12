using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressTracker : MonoBehaviour
{
    public bool isGreenHouseComplete;
    public bool isStorageComplete;
    public bool isCrewQuartersComplete;

    public int teleportStatusCode;

    public Transform greenHousePortalSpawn;
    public Transform storagePortalSpawn;
    public Transform crewCabinSpawn;



    

    // Start is called before the first frame update
    void Start()
    {
        isGreenHouseComplete = false;
        isStorageComplete = false;
        isCrewQuartersComplete = false;

        teleportStatusCode = 0;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTeleportStatus(int statusNumber)
    {
        teleportStatusCode = statusNumber;
    }

    
}

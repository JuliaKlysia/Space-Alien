using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public bool isCorridorPortalOpen;
    public string sceneOfDeath;

  

    // Start is called before the first frame update
    void Start()
    {
        sceneOfDeath = null;
        isCorridorPortalOpen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePortalAccess()
    {
        isCorridorPortalOpen = true;
       
    }
}

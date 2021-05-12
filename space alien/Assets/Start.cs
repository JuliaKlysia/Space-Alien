using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Start : MonoBehaviour

{
    public string LevelToLoad;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        Application.LoadLevel(LevelToLoad);
    }
}

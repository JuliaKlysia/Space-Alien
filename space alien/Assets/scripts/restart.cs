using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    

    

    public void ScreenLoader()
    {
        DontDestroyOnLoad(GameObject.Find("ProgressManager"));
        SceneManager.LoadScene(GameObject.Find("ProgressManager").GetComponent<LevelProgress>().sceneOfDeath);
    }
}

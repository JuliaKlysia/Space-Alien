using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorridorPortal : MonoBehaviour
{

    private string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("ProgressManager"));
        currentLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && GameObject.Find("ProgressManager").GetComponent<LevelProgress>().isCorridorPortalOpen)
        {
            switch (currentLevel)
            {
                case "green house":
                    GameObject.Find("ProgressManager").SendMessage("UpdateTeleportStatus", 3);
                    GameObject.Find("ProgressManager").GetComponent<LevelProgress>().isCorridorPortalOpen = false;
                    SceneManager.LoadScene("corridor");
                    break;
                case "storage":
                    GameObject.Find("ProgressManager").SendMessage("UpdateTeleportStatus", 2);
                    GameObject.Find("ProgressManager").GetComponent<LevelProgress>().isCorridorPortalOpen = false;
                    SceneManager.LoadScene("corridor");
                    break;
                case "crewquater":
                    GameObject.Find("ProgressManager").SendMessage("UpdateTeleportStatus", 1);
                    GameObject.Find("ProgressManager").GetComponent<LevelProgress>().isCorridorPortalOpen = false;
                    SceneManager.LoadScene("corridor");
                    break;
                default:
                    break;
            }
            
        }
    }
}

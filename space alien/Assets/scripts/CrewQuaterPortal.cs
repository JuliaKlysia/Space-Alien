using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrewQuaterPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("ProgressManager"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameObject.Find("ProgressManager").GetComponent<ProgressTracker>().isCrewQuartersComplete == false)
        {
            SceneManager.LoadScene("crewquater");
        }
        else
        {
            //do absolutely nothing xD
        }
    }
}

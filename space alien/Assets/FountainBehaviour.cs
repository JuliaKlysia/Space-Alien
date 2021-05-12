using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainBehaviour : MonoBehaviour
{
    private int puzzlesFinished;

    public Sprite coveredPipe;
    // Start is called before the first frame update
    void Start()
    {
        puzzlesFinished = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateFountain(int finishedPuzzleIncrement)
    {
        puzzlesFinished += finishedPuzzleIncrement;

        if(puzzlesFinished == 2)
        {
            GetComponent<SpriteRenderer>().sprite = coveredPipe;
        }
    }
}

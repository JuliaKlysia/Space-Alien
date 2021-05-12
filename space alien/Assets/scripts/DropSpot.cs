using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSpot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public GameObject correctItem;
    private GameObject puzzleChecker;


    

    // Start is called before the first frame update
    void Start()
    {
        puzzleChecker = GameObject.Find("PuzzleChecker");
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            Debug.Log("It fits, lul"); 
            item = draggHandler.ItemDragging;
            if(item == correctItem)
            {
                puzzleChecker.SendMessage("UpdatePuzzle", 1); 
                item.GetComponent<draggHandler>().enabled = false;
                gameObject.GetComponent<DropSpot>().enabled = false;
            }
            item.transform.SetParent(transform.GetChild(0));
            item.transform.position = transform.GetChild(0).transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }

        
    }
}


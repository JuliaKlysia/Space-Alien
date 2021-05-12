using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggController : MonoBehaviour
{
    private bool _isDragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private draggable lastdragged;
    // Start is called before the first frame update
    void Awake()
    {
        draggController[] controllers = FindObjectsOfType<draggController>();
        if( controllers.Length > 1)
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        
    }
    void InitDrag()
    {
        _isDragActive = true;
    }
    // Update is called once per frame
    void Update()
    { if (_isDragActive && (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);

        }
        else if (Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        if (_isDragActive)
        {
            Drag();
        }
        else
            {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                draggable draggables = hit.transform.gameObject.GetComponent<draggable>();
                if (draggables != null)
                {
                    lastdragged = draggables;
                    InitDrag();
                }
            }
        }
    }
    void Drag()
    {
        lastdragged.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }
    void Drop()
    {
        _isDragActive = false;
    }
}

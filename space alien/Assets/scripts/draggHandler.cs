using UnityEngine;
using UnityEngine.EventSystems;

public class draggHandler : MonoBehaviour, IDragHandler , IEndDragHandler, IBeginDragHandler
{
    public static GameObject ItemDragging;
    Vector3 startPosition;
    Transform startParent;
    Transform DragParent;

   

    void Start()
    {
        DragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
        ItemDragging = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(DragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ondrag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log("OnEndDrag");
        ItemDragging = null;  
        if (transform.parent == DragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

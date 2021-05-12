using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    private Transform playerTransform;
    public float offset;
    public float CameraDistance = 40.0f;
    public float offset1;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / CameraDistance);
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.x += offset;
        temp.y = playerTransform.position.y;
        temp.y += offset1;

        transform.position = temp;

    }
}

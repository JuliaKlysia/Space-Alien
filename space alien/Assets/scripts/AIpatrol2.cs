using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpatrol2 : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool moveleft = true;
    public Transform GroundDetector;

     void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetector.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if(moveleft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveleft = false;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveleft = true;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyanimation : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
  
    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
       if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
            transform.eulerAngles = new Vector3(0, -180, 0);
           

        }
        if( transform.position == pos2.position)
        {
            nextPos = pos1.position;
            transform.eulerAngles = new Vector3(0, 0, 0);
       
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}

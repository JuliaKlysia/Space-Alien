using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public Transform[] movespot;
    private int randomspot;
    private float waittime;
    public float startwaittime;

    // Start is called before the first frame update
    void Start()
    {
        waittime = startwaittime;
        randomspot = Random.Range(0, movespot.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespot[randomspot].position, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, movespot[randomspot].position) < 0.2f)
        {
            if (waittime <= 0)
            {
                randomspot = Random.Range(0, movespot.Length);
                waittime = startwaittime;
                
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchgravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool top;

    private bool isgrounded;
    public Transform groundcheck;
    public float chechradius;
    public LayerMask whatisground;

    void Start()
    {
  
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, chechradius, whatisground);
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded == true)
        {
            rb.gravityScale *= -1;
            Rotation();
        }
    }
    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
            {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }
}

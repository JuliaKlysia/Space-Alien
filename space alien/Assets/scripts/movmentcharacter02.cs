using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movmentcharacter02 : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private bool Facingright = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(Facingright == true && moveInput> 0)
         {
            flip();
         }
           else if (Facingright == false && moveInput < 0)
          {
         flip();
        
          }
     void flip()
        {
            Facingright = !Facingright;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
}

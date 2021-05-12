using System.Collections.Generic;
using UnityEngine;






public class AIpatrol : MonoBehaviour
{
    public float walkSpeed;
    public bool mustPatrol;
    public Rigidbody2D rb;
    private bool mustTurn;
    public Transform groundCheckpos;
    public LayerMask groundLayer;
    void Start()
    {
        mustPatrol = true;

    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

    }
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckpos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    //Hàm lật Nhân vật
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
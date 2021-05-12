
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float MovementSpeed = 1;
    private bool Facingright = true;
  
   
     private void Start()
    {
        
    }

   
   private  void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if ( movement < 0 && !Facingright)
        {
            flip();
        }
        else if(movement > 0 && Facingright)
        {
            flip();
        }
        //    flip();
       // }
         //   else if (Facingright == true)
          //  {
          //  flip();
        //
          //  }
        
    }
    void flip()
    {
       Facingright = !Facingright;
        transform.Rotate(0f, 180f, 0f);
       // Vector3 Scaler = transform.localScale;
       // Scaler.x *= -1;
       // transform.localScale = Scaler;

    }
}

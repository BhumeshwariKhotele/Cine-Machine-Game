using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name=="Player")
        {
         
            collision.collider.GetComponent<PlayerMove>().SuperJump();
          
        }
    }

     
}



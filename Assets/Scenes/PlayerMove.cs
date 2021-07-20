using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float playerSpeed, PlayerJumpForce,playerRadius;
    Rigidbody2D rb;
    bool FaceRight;
    bool isGrounded;
    public LayerMask layerMask;
    public int jumps, maxNumberOfJumps;
    public Transform groundCheck;
    float xinput;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        FaceRight = true;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        jumps = maxNumberOfJumps;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            jumps = maxNumberOfJumps;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerRadius,layerMask);
        xinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xinput * playerSpeed, rb.velocity.y);
    
        if(FaceRight==false && xinput>0)
        {
            Flip();
        }
        else if(FaceRight==true && xinput <0)
        {
            Flip();
        }
        if(Input.GetButtonDown("Jump") && jumps>0)
        {
            rb.velocity = Vector2.up * PlayerJumpForce;
            maxNumberOfJumps -=1;
        }

        if (Input.GetButtonDown("Jump") && jumps==0 && isGrounded==true )
        {
            rb.velocity = Vector2.up * PlayerJumpForce;
        }
    }
    
    void Flip()
    {
        FaceRight =! FaceRight;
        transform.Rotate(0, 180f, 0);
    
    }

    public void SuperJump()
    {
        rb.velocity = Vector2.up * PlayerJumpForce * 1.25f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}

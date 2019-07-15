
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Shuriken;
   // public GameObject shurikens;
    public Transform shurikens;

    Rigidbody2D myRB;
    SpriteRenderer myRenderer;
    Animator myAnim;
    public Vector2 moveInput;

    public  bool facingRight = true;

    //move
    public float maxSpeed;

    //jump
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject shuri = Instantiate(Shuriken, shurikens.position, shurikens.rotation);//(GameObject)Instantiate(Shuriken);
            shuri.transform.position = shurikens.transform.position;

        }
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            myAnim.SetBool("isGrounded", false);
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        float move = Input.GetAxis("Horizontal");


        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        myAnim.SetFloat("MoveSpeed", Mathf.Abs(move));
    }

    void Flip()
    {
        facingRight = !facingRight;        
        //myRenderer.flipX = !myRenderer.flipX;
        transform.Rotate(0f, 180f, 0f);
    } 

}

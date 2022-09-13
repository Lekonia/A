using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_A : MonoBehaviour
{
    public float speed_a;
    public float jumpForce_a;
    private float moveInput_a;

    private Rigidbody2D rb_a;

    private bool facingRight_a = true;

    private bool isGrounded_a;
    public Transform groundCheck_a;
    public float checkRadius_a;
    public LayerMask whatIsGround_a;

    private int extraJumps_a;
    public int extraJumpsValue_a;

    void Start()
    {
        extraJumps_a = extraJumpsValue_a;
        rb_a = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        isGrounded_a = Physics2D.OverlapCircle(groundCheck_a.position, checkRadius_a, whatIsGround_a);

        moveInput_a = Input.GetAxis("Horizontal_a");
       // Debug.Log(moveInput_a);
        rb_a.velocity = new Vector2(moveInput_a * speed_a, rb_a.velocity.y);

        if (facingRight_a == false && moveInput_a > 0)
        {
            Flip();
        }

        else if (facingRight_a == true && moveInput_a < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (isGrounded_a == true)
        {
            extraJumps_a = extraJumpsValue_a;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps_a > 0)
        {
            rb_a.velocity = Vector2.up * jumpForce_a;
            extraJumps_a--;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps_a == 0 && isGrounded_a == true)
        {
            rb_a.velocity = Vector2.up * jumpForce_a;
        }
    }

    void Flip()
    {
        facingRight_a = !facingRight_a;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
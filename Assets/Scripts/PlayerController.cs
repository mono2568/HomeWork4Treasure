using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    //left is false right is true
    private bool move = false;

    private Rigidbody2D rb;
    public bool isGround = false;
    public float maxFallSpeed = -15.0f;

    public float jumpPower = 5f;

    public float jumpGravity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(maxFallSpeed, rb.velocity.y));

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            isGround = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (!isGround && rb.velocity.y > 0.0f && Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = jumpGravity / 2;
        }
        else
        {
            rb.gravityScale = jumpGravity;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        



        //vertical movement
        if (Input.GetKey(KeyCode.A))
        {
            if (move)
            {
                move = false;
                this.transform.localScale = new Vector3(1,1,1);
            }
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);

        }else if (Input.GetKey(KeyCode.D))
        {
            if (!move)
            {
                move = true;
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public float mvmForce;
    public float jmpForce;

    public float maxSpeed;

    private int orientation = 1;

    private bool[] allowed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        allowed = new bool[4]; //W A S D
        allowed[0] = true;
        allowed[1] = true;
        allowed[2] = true;
        allowed[3] = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
    }

    void CheckMovement()
    {
        if (Mathf.Abs(rb2d.velocity.x) < maxSpeed)
        {
            if (allowed[3] && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                rb2d.AddForce(new Vector2(mvmForce, 0));
            }
            if (allowed[1] && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                rb2d.AddForce(new Vector2(-mvmForce, 0));
            }
        }
        if (allowed[0] && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * orientation, 0.7f);
            if (hit.collider != null)
            {
                Jump();
            }
        }
        if(allowed[2] && (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * orientation, 0.7f, 1 << LayerMask.NameToLayer("Dotted"));
            if(hit.collider != null)
            {
                DottedPlatform platform = hit.collider.gameObject.GetComponent<DottedPlatform>();
                platform.Ghost();
            }
        }
    }

    public void ReverseGravity()
    {
        rb2d.gravityScale *= -1;
        orientation *= -1;
    }

    public void Jump()
    {
        rb2d.AddForce(new Vector2(0, jmpForce * orientation));
    }
}

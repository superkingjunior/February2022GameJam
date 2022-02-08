using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public float mvmForce;
    public float jmpForce;

    public float maxSpeed;

    private int orientationUD = 1;
    private int orientationLR = 1;

    public bool[] allowed = new bool[4];

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //allowed = new bool[4]; //W A S D
        // allowed[0] = true;
        // allowed[1] = true;
        // allowed[2] = true;
        // allowed[3] = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            Reset();
        }
        CheckMovement();
    }

    void CheckMovement()
    {
        if ((orientationLR == 1 && rb2d.velocity.x < maxSpeed) || (orientationLR == -1 && rb2d.velocity.x > -maxSpeed))
        {
            if (allowed[3] && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                rb2d.AddForce(new Vector2(mvmForce, 0) * orientationLR * Time.deltaTime);
            }
        }
        if ((orientationLR == -1 && rb2d.velocity.x < maxSpeed) || (orientationLR == 1 && rb2d.velocity.x > -maxSpeed))
        {
            if (allowed[1] && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                rb2d.AddForce(new Vector2(-mvmForce, 0) * orientationLR * Time.deltaTime);
            }
        }
        if (allowed[0] && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * orientationUD, 0.7f);
            if (hit.collider != null)
            {
                Jump();
            }
        }
        if(allowed[2] && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * orientationUD, 0.7f, 1 << LayerMask.NameToLayer("Dotted"));
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
        orientationUD *= -1;
    }

    public void Jump()
    {
        rb2d.AddForce(new Vector2(0, jmpForce * orientationUD));
    }

    public void Jump(float force)
    {
        rb2d.AddForce(new Vector2(0, force * orientationUD));
    }

    public void Flip()
    {
        orientationLR *= -1;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void activate(int id)
    {
        if(id < 4)
        {
            allowed[id] = true;
        }
    }
}

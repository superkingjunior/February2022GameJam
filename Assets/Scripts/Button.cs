using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public float mvmForce;
    public float jmpForce;

    private bool[] allowed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        allowed = new bool[3]; //D A Space
        allowed[0] = true;
        allowed[1] = true;
        allowed[2] = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(rb2d.velocity.x) < 10)
        {
            if (allowed[0] && Input.GetKey(KeyCode.D))
            {
                rb2d.AddForce(new Vector2(mvmForce, 0));
            }
            if (allowed[1] && Input.GetKey(KeyCode.A))
            {
                rb2d.AddForce(new Vector2(-mvmForce, 0));
            }
        }
        if (allowed[2] && Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                rb2d.AddForce(new Vector2(0, jmpForce));
            }
        }
    }
}

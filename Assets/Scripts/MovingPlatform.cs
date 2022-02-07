using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Rigidbody2D myRb2D;

    public float speedX;
    public float speedY;
    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = myRb2D.velocity;
        Vector2 normalizedDir = myRb2D.velocity.normalized;
        vel.x = speedX;
        vel.y = speedY;
        myRb2D.velocity = vel;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("NameOfButton")){
            // A line that updates flapping force of obj in case of bouncing
            print("Collision with static platform");
            
        }
    }

    
}

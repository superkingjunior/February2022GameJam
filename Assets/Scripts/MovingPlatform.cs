using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Rigidbody2D myRb2D;

    public float speedX;
    public float speedY;
    Vector2 vel;

    // the time platform would take to move in one direction
    public float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        myRb2D.velocity = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        vel = myRb2D.velocity;
        Vector2 normalizedDir = myRb2D.velocity.normalized;
        if(transform.position.x < -7){
            vel.x = -vel.x;
            myRb2D.velocity = vel;
        }
        if(transform.position.x > 7){
            vel.x = -vel.x;
            myRb2D.velocity = vel;
        }
        if(transform.position.y < -2){
            vel.y = -vel.y;
            myRb2D.velocity = vel;
        }
        if(transform.position.y > 2){
            vel.y = -vel.y;
            myRb2D.velocity = vel;
        }
        if(timer <= 0){
        //while(vel.x==0){
        vel.x = Random.Range(-2,2);
        //while(vel.y==0){
        vel.y = Random.Range(-2,2);
        timer = 1;
        myRb2D.velocity = vel;}
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            // A line that updates flapping force of obj in case of bouncing
            print("Collision with dynamic platform");
        }
        if(col.gameObject.CompareTag("StaticPlatform")){
            vel.x = -vel.x;
            vel.y = -vel.y;
            myRb2D.velocity = vel;
            print("moving vs collision");
        }
    }

    
}

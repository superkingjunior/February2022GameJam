using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D myRb2D;

    Vector2 vel;
    float velX = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
  
        while(velX==0){
        velX = Random.Range(-1,1);}
        myRb2D.velocity = new Vector2(velX,0);
    }

    // Update is called once per frame
    void Update()
    {
        vel = myRb2D.velocity;
        // makes sure enemy don't go out of bounds
        if(transform.position.x < -7){
            vel.x = -vel.x;
        }
        else if(transform.position.x > 7){
            vel.x = -vel.x;
        }
        // if enemy is getting off platform then switch direction
        if(!OnPlatform()){
            var posX = new Vector3(transform.position.x -0.1f,transform.position.y, 0);
            
            vel.x = -vel.x;
        }
        myRb2D.velocity = vel;
    }

    void OnCollisionEnter2D(Collision2D col){
        // if enemy hitts button the game resets
        if(col.gameObject.CompareTag("Button")){
            Button button = col.gameObject.GetComponent<Button>();
            //button.Reset();
            print("button hit enemies");
        }
        // if enemy hits another object then it switch direction
        else {
            vel.x = -vel.x;
            myRb2D.velocity = vel;
        }
    }
    // Sends a raycast below to see if enemy is on the platform
    bool OnPlatform()
     {
        Vector2 origin = this.transform.position+ new Vector3(0,-0.8f,0);
		Vector2 target = this.transform.position + new Vector3(0,-1.5f,0);
		Vector2 direction = target - origin;
		RaycastHit2D hit = Physics2D.Raycast(origin, direction, direction.magnitude);
        Debug.DrawRay(origin,direction,Color.red, 10f);
		if(hit.collider!= null){
            //print("on platform");
			return true;
		}
        print("off platform");
        return false;
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Rigidbody2D myRb2D;

    Vector2 vel;

    // the time platform would take to move in one direction
    public float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        var velX =0;
        var velY =0;
        while(velX==0){
        velX = Random.Range(-1,1);}
        while(velY==0){
        velY = Random.Range(-1,1);}
        myRb2D.velocity = new Vector2(velX,velY);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        vel = myRb2D.velocity;
        Vector2 normalizedDir = myRb2D.velocity.normalized;
        if(transform.position.x < -2){
            vel.x = -vel.x;
            myRb2D.velocity = vel;
        }
        if(transform.position.x > 2){
            vel.x = -vel.x;
            myRb2D.velocity = vel;
        }
        if(transform.position.y < -3){
            vel.y = -vel.y;
            myRb2D.velocity = vel;
        }
        if(transform.position.y > 3){
            vel.y = -vel.y;
            myRb2D.velocity = vel;
        }
        AboutToHit();
        
    }

    void AboutToHit(){
        // check below
        Vector2 origin = this.transform.position+ new Vector3(0,-0.3f,0);
		Vector2 targetDown = this.transform.position + new Vector3(0,-2f,0);
		Vector2 directionDown = targetDown - origin;
		RaycastHit2D hitDown = Physics2D.Raycast(origin, directionDown, directionDown.magnitude);
        Debug.DrawRay(origin,directionDown,Color.red, 10f);

        // check above
        origin = this.transform.position+ new Vector3(0,0.3f,0);
		Vector2 targetUp = this.transform.position + new Vector3(0,2f,0);
		Vector2 directionUp = targetUp - origin;
		RaycastHit2D hitUp = Physics2D.Raycast(origin, directionUp, directionUp.magnitude);
        Debug.DrawRay(origin,directionUp,Color.green, 10f);

        // check right
        origin = this.transform.position+ new Vector3(1.7f,0,0);
		Vector2 targetRight = this.transform.position + new Vector3(3,0,0);
		Vector2 directionRight = targetRight - origin;
		RaycastHit2D hitRight = Physics2D.Raycast(origin, directionRight, directionUp.magnitude);
        Debug.DrawRay(origin,directionRight,Color.blue, 10f);

        // check left
        origin = this.transform.position+ new Vector3(-1.7f,0,0);
		Vector2 targetLeft = this.transform.position + new Vector3(-3,0,0);
		Vector2 directionLeft = targetLeft - origin;
		RaycastHit2D hitLeft = Physics2D.Raycast(origin, directionLeft, directionUp.magnitude);
        Debug.DrawRay(origin,directionLeft,Color.yellow, 10f);
		if(hitUp.collider!= null || hitDown.collider!=null){
            vel.y = -vel.y;
            myRb2D.velocity = vel;
		}
        else if(hitRight.collider!= null || hitLeft.collider!=null){
            print("outta bounds");
            vel.x = -vel.x;
            myRb2D.velocity = vel;
		}

    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            // A line that updates flapping force of obj in case of bouncing
            print("Collision with dynamic platform");
        }
        else{
            vel.x = -vel.x;
            vel.y = -vel.y;
            myRb2D.velocity = vel;
            print("moving vs collision");
        }
    }

    
}

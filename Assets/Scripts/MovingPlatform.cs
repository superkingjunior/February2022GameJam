using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Rigidbody2D myRb2D;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        var velX =0;
        while(velX==0){
        velX = Random.Range(-1,1);}
        myRb2D.velocity = new Vector2(velX,0);
    }

    // Update is called once per frame
    void Update()
    {
        vel = myRb2D.velocity;
        AboutToHit();
        
    }

    void AboutToHit(){


        // check right
        Vector2 origin = this.transform.position+ new Vector3(1.7f,0,0);
		Vector2 targetRight = this.transform.position + new Vector3(3,0,0);
		Vector2 directionRight = targetRight - origin;
		RaycastHit2D hitRight = Physics2D.Raycast(origin, directionRight, directionRight.magnitude);
        Debug.DrawRay(origin,directionRight,Color.blue, 10f);

        // check left
        origin = this.transform.position+ new Vector3(-1.7f,0,0);
		Vector2 targetLeft = this.transform.position + new Vector3(-3,0,0);
		Vector2 directionLeft = targetLeft - origin;
		RaycastHit2D hitLeft = Physics2D.Raycast(origin, directionLeft, directionLeft.magnitude);
        Debug.DrawRay(origin,directionLeft,Color.yellow, 10f);
        if(hitRight.collider!= null || hitLeft.collider!=null){
            vel.x = -vel.x;
            myRb2D.velocity = vel;
		}

    }
    
}

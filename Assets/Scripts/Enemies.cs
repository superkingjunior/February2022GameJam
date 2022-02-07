using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D myRb2D;

    Vector2 vel;

    public float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        /*myRb2D = GetComponent<Rigidbody2D>();
        myRb2D.velocity = new Vector2((Random.Range(-1,1)),0);*/
    }

    // Update is called once per frame
    void Update()
    {
        /*timer -= Time.deltaTime;
        vel = myRb2D.velocity;
        if(transform.position.x < -7){
            vel.x = -vel.x;
            myRb2D.velocity = vel;
        }
        if(transform.position.x > 7){
            vel.x = -vel.x;
            myRb2D.velocity = vel;
        }
        if(timer <=0){
            vel.x = Random.Range(-2,2);
            timer =-1;
            myRb2D.velocity = vel;
        }*/
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            Button button = col.gameObject.GetComponent<Button>();
            //button.Kill();
            print("button hit enemies");
        }
    }
}

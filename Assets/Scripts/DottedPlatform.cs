using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedPlatform : MonoBehaviour
{

    private BoxCollider2D bc2d;


    private void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

    public void Ghost()
    {
        bc2d.isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        bc2d.isTrigger = false;
    }

    /*
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            // A line that updates flapping force of obj in case of bouncing
            print("Collision with dotted platform");
            
        }
    }
    */
}

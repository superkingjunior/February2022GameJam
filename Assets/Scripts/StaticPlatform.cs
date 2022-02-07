using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatform : MonoBehaviour
{
    // In case we need it to be used as a bouncer
    public float flapForce;

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            // A line that updates flapping force of obj in case of bouncing
            print("Collision with static platform");
            
        }
    }
}

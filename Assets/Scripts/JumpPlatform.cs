using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{

    public float force;

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            Button button = col.gameObject.GetComponent<Button>();
            button.Jump(force);
            //print("Hit jumping platform");

        }
    }
}

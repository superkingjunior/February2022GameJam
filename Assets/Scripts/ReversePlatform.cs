using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePlatform : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            Button button = col.gameObject.GetComponent<Button>();
            button.ReverseGravity();
        }
    }
}

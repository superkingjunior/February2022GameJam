using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Button")){
            print("Button hit spikes");
            Button button = col.gameObject.GetComponent<Button>();
            button.Reset();
        }
    }
}

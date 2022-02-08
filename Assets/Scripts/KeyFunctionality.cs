using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunctionality : MonoBehaviour
{

    private SpriteRenderer[] keySprites;

    public GameObject keys;
    
    public Transform button;
    // Start is called before the first frame update
    void Start()
    {
        keySprites = keys.GetComponentsInChildren<SpriteRenderer>();

        // Debug.Log(keySprites[0].name);
        // Debug.Log(keySprites[1].name);
        // Debug.Log(keySprites[2].name);
        // Debug.Log(keySprites[3].name);

        Debug.Log(keySprites[0].transform.localPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

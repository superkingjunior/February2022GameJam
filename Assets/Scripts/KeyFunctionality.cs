using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunctionality : MonoBehaviour
{

    private SpriteRenderer[] keySprites;

    public GameObject keys;

    private Button buttonScript;

    // Start is called before the first frame update
    void Start()
    {
        keySprites = keys.GetComponentsInChildren<SpriteRenderer>();
        buttonScript = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonScript.allowed[0])
        {
             keySprites[0].enabled = true;
             KeyPosition(1f, keySprites[0]);
        }
        else
        {
            keySprites[0].enabled = false;
        }
        
        if (buttonScript.allowed[1])
        {
             keySprites[1].enabled = true;
             KeyPosition(.35f, keySprites[1]);
        }
        else
        {
            keySprites[1].enabled = false;
        }
        
        if (buttonScript.allowed[2])
        {
             keySprites[2].enabled = true;
             KeyPosition(-.35f, keySprites[2]);
        }
        else
        {
            keySprites[2].enabled = false;
        }
        
        if (buttonScript.allowed[3])
        {
             keySprites[3].enabled = true;
             KeyPosition(-1f, keySprites[3]);  
        }
        else
        {
            keySprites[3].enabled = false;
        }
        
    }

    void KeyPosition(float offset, SpriteRenderer keySprite)
    {
        Vector3 veccy = new Vector3(transform.position.x - offset, transform.position.y + 1f, transform.position.z);
        keySprite.transform.position = veccy;
        keySprite.transform.rotation = Quaternion.identity;
    }
}

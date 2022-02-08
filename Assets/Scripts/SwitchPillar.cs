using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPillar : MonoBehaviour
{

    public bool destroyOnImpact = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            Button button = collision.gameObject.GetComponent<Button>();
            button.Flip();
            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }
}

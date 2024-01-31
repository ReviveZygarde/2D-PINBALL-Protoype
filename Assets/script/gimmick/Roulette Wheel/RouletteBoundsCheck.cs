using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBoundsCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pinball")
        {
            collision.gameObject.layer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

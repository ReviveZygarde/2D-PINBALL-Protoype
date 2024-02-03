using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits_scrollup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1f, 0) * Time.deltaTime);
    }
}

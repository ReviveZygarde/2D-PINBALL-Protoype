using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warning_moveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       this.transform.localPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
    }
}

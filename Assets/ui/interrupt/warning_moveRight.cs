using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning_moveRight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isActiveAndEnabled)
        {
            this.transform.localPosition = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
    }
}

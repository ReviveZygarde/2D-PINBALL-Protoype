using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class axisCopyY : MonoBehaviour
{
    public GameObject objectToCopy_Y;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(0, objectToCopy_Y.transform.position.y);
    }
}

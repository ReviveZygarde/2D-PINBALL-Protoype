using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceUpright : MonoBehaviour
{
    [Tooltip("Force the sprite at a specific rotation. This is useful if you want to force" +
        " the appearance of the ball sprite to not rotate while it is moving, especially if" +
        " the sprite has a baked shadow. If you do not need this, simply remove the" +
        " component.")]
    [SerializeField] private Vector3 rotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(rotation);
    }
}

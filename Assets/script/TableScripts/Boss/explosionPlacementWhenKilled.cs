using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionPlacementWhenKilled : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    private void OnEnable()
    {
        transform.position = target.position;
    }
}

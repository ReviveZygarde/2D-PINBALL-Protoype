using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reEnabler : MonoBehaviour
{
    [SerializeField] private arrowLightsBehavior arrowLights;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(arrowLights.enabled == false)
        {
            arrowLights.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railwayLineTallier : MonoBehaviour
{
    public enum tallyType {NONE, BOSS, RUSH, RHYTHM}
    public tallyType type;
    public GameObject Pinball;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Pinball)
        {
            doTheTally();
        }
    }

    void doTheTally()
    {
        switch (type)
        {
            case tallyType.NONE:
                break;
            case tallyType.BOSS:
                break;
            case tallyType.RUSH:
                break;
            case tallyType.RHYTHM:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

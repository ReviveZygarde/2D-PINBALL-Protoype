using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableThenEnable : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToDisable;
    [SerializeField] private GameObject ObjectToEnable;

    public void disableDesiredObject()
    {
        ObjectToDisable.SetActive(false);
        ObjectToEnable.SetActive(true);
    }
}

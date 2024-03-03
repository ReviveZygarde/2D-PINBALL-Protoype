using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_waitToActivateObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToActivate());
    }

    IEnumerator waitToActivate()
    {
        yield return new WaitForSeconds(timer);
        objectToActivate.SetActive(true);
    }
}

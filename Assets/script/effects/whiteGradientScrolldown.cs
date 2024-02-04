using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteGradientScrolldown : MonoBehaviour
{
    private Vector2 originalObjectTransform;

    // Start is called before the first frame update
    void Start()
    {
        originalObjectTransform = this.transform.position;
    }

    private void OnDisable()
    {
        transform.position = originalObjectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 30 * Time.deltaTime, Space.Self);
    }
}

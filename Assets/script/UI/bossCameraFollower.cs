using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCameraFollower : MonoBehaviour
{
    public GameObject bossEntity;
    private SpriteRenderer sprr;

    // Start is called before the first frame update
    void Start()
    {
        bossEntity = GameObject.Find("bossEntity");
        sprr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(flashing());
    }

    IEnumerator flashing()
    {
        while (this.enabled)
        {
            yield return new WaitForSeconds(0.25f);
            sprr.enabled = false;
            yield return new WaitForSeconds(0.25f);
            sprr.enabled = true;
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        //just like how the AxisCopyY script works.
        transform.position = new Vector2(bossEntity.transform.position.x, this.transform.position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCameraFollower : MonoBehaviour
{
    public GameObject bossEntity;

    // Start is called before the first frame update
    void Start()
    {
        bossEntity = GameObject.Find("bossEntity");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(bossEntity.transform.position.x, this.transform.position.y);
    }
}

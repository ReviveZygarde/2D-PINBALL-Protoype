using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpriteAnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject NE;
    [SerializeField] private GameObject SE;
    [SerializeField] private GameObject SW;
    [SerializeField] private GameObject NW;
    [SerializeField] private GameObject defeat;
    [SerializeField] private Rigidbody2D entityRigidbody;
    [SerializeField] private BossCollision bossStatus;

    // Start is called before the first frame update
    void Start()
    {
        bossStatus = GetComponent<BossCollision>();
        entityRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        defeat.SetActive(false);
    }

    // Update is called once per frame
    void Update() //this is some yanderedev type beat coding and I hate it.
    {
        if(entityRigidbody.velocity.x > 0.001 && entityRigidbody.velocity.y > 0.001) //(1,1) NE isometric animation
        {
            NE.SetActive(true);
            SE.SetActive(false);
            SW.SetActive(false);
            NW.SetActive(false);
        }
        if(entityRigidbody.velocity.x > 0.001 && entityRigidbody.velocity.y < -0.001) //(1,-1) SE isometric animation
        {
            NE.SetActive(false);
            SE.SetActive(true);
            SW.SetActive(false);
            NW.SetActive(false);
        }
        if (entityRigidbody.velocity.x < -0.001 && entityRigidbody.velocity.y < -0.001) //(-1,-1) SW isometric animation
        {
            NE.SetActive(false);
            SE.SetActive(false);
            SW.SetActive(true);
            NW.SetActive(false);
        }
        if (entityRigidbody.velocity.x < -0.001 && entityRigidbody.velocity.y > 0.001) //(-1,1) NW isometric animation
        {
            NE.SetActive(false);
            SE.SetActive(false);
            SW.SetActive(false);
            NW.SetActive(true);
        }
        if (bossStatus.isDefeated)
        {
            defeat.SetActive(true);
            NE.SetActive(false);
            SE.SetActive(false);
            SW.SetActive(false);
            NW.SetActive(false);
        }
    }
}

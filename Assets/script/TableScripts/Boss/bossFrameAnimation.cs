using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFrameAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D entityRigidbody;
    private BossCollision bossData;
    [SerializeField] private GameObject[] animationNE;
    [SerializeField] private GameObject[] animationSE;
    [SerializeField] private GameObject[] animationSW;
    [SerializeField] private GameObject[] animationNW;
    [SerializeField] private GameObject defeatSprite;

    void Start()
    {
        entityRigidbody = GetComponent<Rigidbody2D>();
        bossData = GetComponent<BossCollision>();
        //StartCoroutine(spriteAnimationPlayback());
    }

    private void OnEnable()
    {
        StartCoroutine(spriteAnimationPlayback());
    }

    IEnumerator spriteAnimationPlayback()
    {
        if(bossData.isDefeated == false)
        {
            while (entityRigidbody.velocity.x > 1 && entityRigidbody.velocity.y > 1) //(1,1) NE isometric animation
            {
                //cycle each index in the array.
                for (int i = 0; i < animationNE.Length; i++)
                {
                    animationNE[i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    animationNE[i].gameObject.SetActive(false);
                    i++;
                    if (i >= animationNE.Length)
                    {
                        i = 0;
                    }

                }
                yield return new WaitForSeconds(0.5f);
            }
            while (entityRigidbody.velocity.x > 1 && entityRigidbody.velocity.y < -1) //(1,-1) SE isometric animation
            {

            }
            while (entityRigidbody.velocity.x < -1 && entityRigidbody.velocity.y < -1) //(-1,-1) SW isometric animation
            {

            }
            while (entityRigidbody.velocity.x < -1 && entityRigidbody.velocity.y > 1) //(-1,1) NW isometric animation
            {

            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossData.isDefeated)
        {
            defeatSprite.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

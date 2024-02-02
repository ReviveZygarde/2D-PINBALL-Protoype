using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entitySpriteAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] frameAnimation;

    private void OnEnable()
    {
        StartCoroutine(spriteAnimation());
    }

    IEnumerator spriteAnimation()
    {
        for (int i = 0; i < frameAnimation.Length; i++)
        {
            frameAnimation[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            frameAnimation[i].gameObject.SetActive(false);
            i++;
            if (i >= frameAnimation.Length)
            {
                i = 0;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}

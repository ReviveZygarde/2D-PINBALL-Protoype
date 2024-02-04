using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class entitySpriteAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] frameAnimation;

    private void OnEnable()
    {
        StartCoroutine(spriteAnimation());
    }

    IEnumerator spriteAnimation() //infinitely loops this coroutine to simulate an animating sprite.
    {
        for (int i = 0; i < frameAnimation.Length + 1; i++)
        {
            Debug.Log($"Boss Debug: Animation at frame {i} of {frameAnimation.Length}");
            if (i >= frameAnimation.Length)
            {
                i = 0;
            }
            frameAnimation[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            frameAnimation[i].gameObject.SetActive(false);
        }
    }
}

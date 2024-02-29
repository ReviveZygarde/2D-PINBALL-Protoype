using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintPlayer : MonoBehaviour
{
    [SerializeField] private Text hintText;
    [SerializeField] private string[] hints;
    [SerializeField] private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        hintText = GetComponent<Text>();
        StopAllCoroutines();
        StartCoroutine(hintCycle());
    }

    IEnumerator hintCycle()
    {
        for (int i = 0; i < hints.Length + 1; i++)
        {
            if (i >= hints.Length)
            {
                i = 0;
            }
            hintText.text = hints[i];
            yield return new WaitForSecondsRealtime(waitTime);
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

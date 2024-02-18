using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    private Image image;
    public GameObject blackBars;
    public AudioSource BGM;
    //private Color imageColor;
    // Start is called before the first frame update
    void Start()
    {
        if (BGM.isPlaying)
        {
            BGM.Stop();
        }
        image = GetComponent<Image>();
        StartCoroutine(FadeImage());
        //imageColor = image.color;
    }

    IEnumerator FadeImage()
    {
        // loop over 1 second
        for (float i = 0; i <= 1.05; i += Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(1, 1, 1, i);
            blackBars.SetActive(true);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        if(image.color.a == 1)
        {
            blackBars.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

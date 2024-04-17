using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkEffectOptionMenu : MonoBehaviour
{
    private Text text;
    [SerializeField] GameObject OnImage;
    [SerializeField] GameObject OffImage;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalSetting.Instance.postprocessEffectsEnabled)
        {
            text.text = "ON";
            OnImage.SetActive(true);
            OffImage.SetActive(false);
        }
        else
        {
            text.text = "OFF";
            OnImage.SetActive(false);
            OffImage.SetActive(true);
        }
    }
}

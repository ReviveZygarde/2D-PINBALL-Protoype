using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChangerByControlType : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text text;
    [SerializeField] private string PromptTextForA;
    [SerializeField] private string PromptTextForB;
    [SerializeField] private string PromptTextForC;

    void Start()
    {
        text = GetComponent<Text>();
        switch (globalSetting.Instance.Control_Type)
        {
            case globalSetting.controlType.A:
                text.text = PromptTextForA;
                break;
            case globalSetting.controlType.B:
                text.text = PromptTextForB;
                break;
            case globalSetting.controlType.C:
                text.text = PromptTextForC;
            break;
        }
    }
}

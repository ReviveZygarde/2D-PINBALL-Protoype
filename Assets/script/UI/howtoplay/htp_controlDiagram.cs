using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class htp_controlDiagram : MonoBehaviour
{
    [SerializeField] GameObject diagramA;
    [SerializeField] GameObject diagramB;
    [SerializeField] GameObject diagramC;

    // Start is called before the first frame update
    void Start()
    {
        switch(globalSetting.Instance.Control_Type)
        {
            case globalSetting.controlType.A: diagramA.SetActive(true); break;
            case globalSetting.controlType.B: diagramB.SetActive(true); break;
            case globalSetting.controlType.C: diagramC.SetActive(true); break;
        }
    }
}

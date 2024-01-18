using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class debugMasterMenuBehavior : MonoBehaviour
{
    public globalSetting gl_setting;
    public Text ballMass;
    public Text controltypetext;
    public Text gmlanguageset;
    public GameObject controlDiagramA;
    public GameObject controlDiagramB;
    public GameObject controlDiagramC;

    // Start is called before the first frame update
    void Start()
    {
        gl_setting = globalSetting.Instance;
        ballMass.text = gl_setting.ballSetting.ToString();
        controltypetext.text = gl_setting.Control_Type.ToString();
        gmlanguageset.text = gl_setting.languageType.ToString();
    }

    public void changeBallMass()
    {
        if(gl_setting.ballSetting == globalSetting.ballMass.NORMAL)
        {
            gl_setting.ballSetting = globalSetting.ballMass.LIGHT;
        }
        else
        {
            gl_setting.ballSetting = globalSetting.ballMass.NORMAL;
        }
        ballMass.text = gl_setting.ballSetting.ToString();
    }

    public void changeControlType()
    {
        //This is not good to write it like this but no one will see this by normal means.

        if(gl_setting.Control_Type == globalSetting.controlType.A)
        {
            gl_setting.Control_Type = globalSetting.controlType.B;
            controlDiagramA.SetActive(false);
            controlDiagramB.SetActive(true);
        }
        else if (gl_setting.Control_Type == globalSetting.controlType.B)
        {
            gl_setting.Control_Type = globalSetting.controlType.C;
            controlDiagramB.SetActive(false);
            controlDiagramC.SetActive(true);
        }
        else if (gl_setting.Control_Type == globalSetting.controlType.C)
        {
            gl_setting.Control_Type = globalSetting.controlType.A;
            controlDiagramC.SetActive(false);
            controlDiagramA.SetActive(true);
        }

        controltypetext.text = gl_setting.Control_Type.ToString();
    }

    public void changeLanguage()
    {
        if(gl_setting.languageType == globalSetting.language.EN)
        {
            gl_setting.languageType = globalSetting.language.JP;
        }
        else
        {
            gl_setting.languageType = globalSetting.language.EN;
        }
        gmlanguageset.text = gl_setting.languageType.ToString();
    }

    public void gotoTitle()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("TitlePrototype");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

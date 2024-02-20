using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public Gamepad gamepad;
    public GameObject blackscreenOver;

    // Start is called before the first frame update
    void Start()
    {
        gl_setting = globalSetting.Instance;
        if(ballMass != null)
        ballMass.text = gl_setting.ballSetting.ToString();
        if(controltypetext != null)
        controltypetext.text = gl_setting.Control_Type.ToString();
        if(gmlanguageset != null)
        gmlanguageset.text = gl_setting.languageType.ToString();
        debugLogging();
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
        string tmp = "TitlePrototype";
        StartCoroutine(wait(tmp));
    }

    IEnumerator wait(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(sceneName);
    }

    public void gotoSelectedScene(Text inputtedText)
    {
        SceneManager.LoadScene(int.Parse(inputtedText.text));
    }

    public void goToPresetSceneForRelease(string sceneName)
    {
        if (GameObject.Find("BGM") != null && GameObject.Find("BGM").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        }
        blackscreenOver.SetActive(true);
        StartCoroutine(wait(sceneName));
    }

    void debugLogging()
    {
        Debug.Log(string.Join("\n", Gamepad.all));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

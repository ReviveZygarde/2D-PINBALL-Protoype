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
    public AudioSource[] ballSettingVO;
    public AudioSource[] controlSettingVO;

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
        switch(gl_setting.ballSetting)
        {
            case globalSetting.ballMass.NORMAL:
                gl_setting.ballSetting = globalSetting.ballMass.LIGHT;
                if(ballSettingVO != null) ballSettingVO[1].Play();
                break;
            case globalSetting.ballMass.LIGHT:
                gl_setting.ballSetting = globalSetting.ballMass.HEAVY;
                if (ballSettingVO != null) ballSettingVO[2].Play();
                break;
            case globalSetting.ballMass.HEAVY:
                if (gl_setting.hasEnteredKonamiCode)
                {
                    gl_setting.ballSetting = globalSetting.ballMass.ULTRA;
                    if (ballSettingVO != null) ballSettingVO[3].Play();
                }
                else
                {
                    gl_setting.ballSetting = globalSetting.ballMass.NORMAL;
                    if (ballSettingVO != null) ballSettingVO[0].Play();
                }
                break;
            case globalSetting.ballMass.ULTRA:
                gl_setting.ballSetting = globalSetting.ballMass.NORMAL;
                if (ballSettingVO != null) ballSettingVO[0].Play();
                break;
        }
        ballMass.text = gl_setting.ballSetting.ToString();
    }

    public void changeControlType()
    {
        if (controlSettingVO != null)
        {
            foreach(AudioSource voClip in controlSettingVO)
            {
                voClip.Stop();
            }
        }
            switch (gl_setting.Control_Type)
        {
            case globalSetting.controlType.A:
                gl_setting.Control_Type = globalSetting.controlType.B;
                controlDiagramA.SetActive(false);
                controlDiagramB.SetActive(true);
                if(controlSettingVO != null) controlSettingVO[1].Play();
                break;
            case globalSetting.controlType.B:
                gl_setting.Control_Type = globalSetting.controlType.C;
                controlDiagramB.SetActive(false);
                controlDiagramC.SetActive(true);
                if (controlSettingVO != null) controlSettingVO[2].Play();
                break;
            case globalSetting.controlType.C:
                gl_setting.Control_Type = globalSetting.controlType.A;
                controlDiagramC.SetActive(false);
                controlDiagramA.SetActive(true);
                if (controlSettingVO != null) controlSettingVO[0].Play();
                break;
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
        string tmp = "rankings";
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
        if (blackscreenOver != null)
        {
            blackscreenOver.SetActive(true);
        }
        StartCoroutine(wait(sceneName));
    }

    void debugLogging()
    {
        Debug.Log(string.Join("\n", Gamepad.all));
    }
}

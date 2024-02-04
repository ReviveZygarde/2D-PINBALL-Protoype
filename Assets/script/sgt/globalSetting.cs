using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;

public class globalSetting : Singleton<globalSetting>
{
    public enum controlType
    {A, B, C}
    public controlType Control_Type = controlType.A;

    public enum ballMass
    {NORMAL, LIGHT}
    public ballMass ballSetting = ballMass.NORMAL;

    public enum language
    {EN, JP}
    public language languageType = language.EN;

    // Start is called before the first frame update
    void Start()
    {
        var gamepad = (DualShockGamepad)Gamepad.all[0];
        gamepad.SetLightBarColor(Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

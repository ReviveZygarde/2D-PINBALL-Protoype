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
    {NORMAL, LIGHT, HEAVY}
    public ballMass ballSetting = ballMass.NORMAL;

    public enum language
    {EN, JP}
    public language languageType = language.EN;

    public enum releaseLevel //RELEASE is for game releases, DEMO is for playtesting and/or game events, DEVELOP is for development.
    {RELEASE, DEMO, DEVELOP}
    public releaseLevel buildType = releaseLevel.DEVELOP;

    // Start is called before the first frame update
    void Start()
    {
        //Optional: Dualshock 4/Dualsense custom lightbar color. Note: only works when the controller is physically plugged in via USB.
        //var gamepad = (DualShockGamepad)Gamepad.all[0];
        //gamepad.SetLightBarColor(Color.blue);
    }
}

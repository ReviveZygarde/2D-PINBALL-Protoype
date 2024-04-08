using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class globalSetting : Singleton<globalSetting>
{
    public enum controlType
    {A, B, C}
    public controlType Control_Type = controlType.A;

    public enum ballMass
    {NORMAL, LIGHT, HEAVY, ULTRA}
    public ballMass ballSetting = ballMass.NORMAL;

    public enum language
    {EN, JP}
    public language languageType = language.EN;

    public enum releaseLevel //RELEASE is for game releases, DEMO is for playtesting and/or game events, DEVELOP is for development.
    {RELEASE, DEMO, DEVELOP}
    public releaseLevel buildType = releaseLevel.DEVELOP;

    public enum stagePlaying
    { CASINO, CITY, FACTORY, NONE}
    public stagePlaying currentStage = stagePlaying.NONE;

    public bool hasEnteredKonamiCode;

    public bool frameRateLimitTo60FPS;
}

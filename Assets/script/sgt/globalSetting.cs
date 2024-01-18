using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalSetting : Singleton<globalSetting>
{
    [Tooltip("ON = Middle Mouse Button will show debug information at runtime." +
        " Useful for testing bulild versions of the game. Turn this off FOR RELEASES.")]
    [SerializeField] private bool runtimeDebugEnable; //This actually has no function yet :p

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

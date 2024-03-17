using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuBallColorChanger : MonoBehaviour
{
    private generic_colorChanger cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<generic_colorChanger>();
    }

    void Update()
    {
        changeBallUIcolor();
    }

    public void changeBallUIcolor()
    {
        switch (globalSetting.Instance.ballSetting)
        {
            case globalSetting.ballMass.NORMAL:
                cc.changeImageColor(0);
                break;
            case globalSetting.ballMass.LIGHT:
                cc.changeImageColor(1);
                break;
            case globalSetting.ballMass.HEAVY:
                cc.changeImageColor(2);
                break;
            case globalSetting.ballMass.ULTRA:
                cc.changeImageColor(3);
                break;
        }
    }
}

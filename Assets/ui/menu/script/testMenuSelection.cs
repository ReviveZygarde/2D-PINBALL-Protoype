using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class testMenuSelection : MonoBehaviour
{
    public Button toFlipper;
    public Button toJumper;
    public Button toSpring;
    public Button toStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        toFlipper.onClick.AddListener(startFlipperTest);
        toJumper.onClick.AddListener(startJumperTest);
        toSpring.onClick.AddListener(startSpringTest);
        toStateMachine.onClick.AddListener(startSMtest);
    }

    void startFlipperTest()
    {
        SceneManager.LoadScene(1);
    }

    void startJumperTest()
    {
        SceneManager.LoadScene(2);
    }

    void startSpringTest()
    {
        SceneManager.LoadScene(3);
    }

    void startSMtest()
    {
        SceneManager.LoadScene("TestTable");
    }
}

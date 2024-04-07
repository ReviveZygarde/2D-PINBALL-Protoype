using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour
{
    public Selectable primaryButton;

    //public GameObject TitleStuff, MainMenu;

    //public GameObject StartDemo, options;

    // Start is called before the first frame update
    void OnEnable()
    {
        primaryButton.Select();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

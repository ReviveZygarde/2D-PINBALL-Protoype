using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect3 : MonoBehaviour
{
    public Selectable firstButton;

    //public GameObject TitleStuff, MainMenu;

    //public GameObject StartDemo, options;

    // Start is called before the first frame update
    void OnEnable()
    {
        firstButton.Select();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

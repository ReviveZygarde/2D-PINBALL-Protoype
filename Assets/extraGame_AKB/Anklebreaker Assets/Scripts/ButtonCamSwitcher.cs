using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class ButtonCamSwitcher : MonoBehaviour,  IPointerDownHandler
{
    public Camera[] MyCameras;
    // Use this for initialization

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (Camera ChosenCamera in MyCameras)
        {
            if (gameObject.name[7] != ChosenCamera.name[7])
            {
                ChosenCamera.GetComponent<Camera>().enabled = false;
            }
            else
            {
                ChosenCamera.GetComponent<Camera>().enabled = true;
            }
            Debug.Log(gameObject.name);
            Debug.Log(ChosenCamera);
        }
    }

}

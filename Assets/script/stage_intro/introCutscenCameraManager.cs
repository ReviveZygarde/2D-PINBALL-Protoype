using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class introCutscenCameraManager : MonoBehaviour
{
    public List<GameObject> cameras;
    public int currentCam = 0;


    public void changeCamera()
    {
        currentCam++;
        cameras[currentCam].SetActive(true);
        int tempCam = currentCam - 1;
        cameras[tempCam].SetActive(false);
    }
}

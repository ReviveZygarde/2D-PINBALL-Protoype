using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtons1 : MonoBehaviour
{



    public Camera MainCamera;
    public GameObject TargetPosition;
    public int speed = 2;
    bool camera1_move_enabled = false;

    void Update()
    {

        if (camera1_move_enabled)
        {
            MainCamera.transform.position = Vector3.Lerp(transform.position, TargetPosition.transform.position, speed * Time.deltaTime);
            MainCamera.transform.rotation = Quaternion.Lerp(transform.rotation, TargetPosition.transform.rotation, speed * Time.deltaTime);
        }

    }

    public void UserClickedCameraButton()
    {
        TargetPosition.transform.position = new Vector3(34.9f, 4.74f, -18.1f);
        TargetPosition.transform.rotation = Quaternion.Euler(2.23f, 98.52f, 0);
        camera1_move_enabled = true;
    }
    
    public void UserClickedCameraButton2()
    {
        TargetPosition.transform.position = new Vector3(88f, 2f, -15.6999998f);
        TargetPosition.transform.rotation = Quaternion.Euler(-12.97f, 47.5999908f, 0);
        camera1_move_enabled = true;
    }
 
    public void UserClickedCameraButton3()
    {
        TargetPosition.transform.position = new Vector3(52.7f, 4.1f, -8.9f);
        TargetPosition.transform.rotation = Quaternion.Euler(-2.23f, -23.13f, 0);
        camera1_move_enabled = true;
    }
    
    public void UserClickedCameraButton4()
    {
        TargetPosition.transform.position = new Vector3(31f, 3.5f, 16f);
        TargetPosition.transform.rotation = Quaternion.Euler(-11.1f, -23.61f, 0);
        camera1_move_enabled = true;
    }

    public void UserClickedCameraButton5()
    {
        //TargetPosition.transform.position = new Vector3(f, f, f);
        TargetPosition.transform.rotation = Quaternion.Euler(2.23f, 98.52f, 0);
        camera1_move_enabled = true;
    }
}
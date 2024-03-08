using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCameraDetection : MonoBehaviour
{
    [SerializeField] private GameObject bossArrowUp;
    [SerializeField] private GameObject bossArrowDown;
    [SerializeField] private GameObject bossEntity;
    [SerializeField] private Renderer bossRenderer;
    private GameObject mainCamera;

    /*
     * Boss Camera Detection
     * Simply detects whether or not the Boss is on-screen, while the
     * Boss is active. It also simply compares the Y-Axis coordinate
     * between the Boss and the Camera, to show the proper arrow
     * indicating the direction the boss is at.
     */

    // Start is called before the first frame update
    void Start()
    {
        //bossEntity = GameObject.Find("bossEntity");
        mainCamera = GameObject.Find("Main Camera");
        bossRenderer = bossEntity.GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = mainCamera.transform.position;
        if (bossEntity.activeSelf == false)
        {
            bossArrowUp.SetActive(false);
            bossArrowDown.SetActive(false);
        }
        else if(bossEntity.activeSelf == true)
        {
            if(bossRenderer.isVisible == false)
            {
                if(bossEntity.transform.position.y > transform.position.y)
                {
                    bossArrowUp.SetActive(true);
                    bossArrowDown.SetActive(false);
                }
                if (bossEntity.transform.position.y < transform.position.y)
                {
                    bossArrowUp.SetActive(false);
                    bossArrowDown.SetActive(true);
                }
            }
            else
            {
                bossArrowUp.SetActive(false);
                bossArrowDown.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCameraDetection : MonoBehaviour
{
    [SerializeField] private GameObject bossArrow;
    [SerializeField] private GameObject bossEntity;
    [SerializeField] private Renderer bossRenderer;
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        bossEntity = GameObject.Find("bossEntity");
        mainCamera = GameObject.Find("Main Camera");
        bossRenderer = bossEntity.GetComponent<Renderer>();
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == bossEntity)
        {
            if(bossEntity.activeSelf == true)
            {
                Debug.Log("Boss is off-screen");
                bossArrow.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == bossEntity)
        {
            Debug.Log("Boss is on-screen");
            bossArrow.SetActive(false);
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        this.transform.position = mainCamera.transform.position;
        if (bossEntity.activeSelf == false)
        {
            bossArrow.SetActive(false);
        }
        else if(bossEntity.activeSelf == true)
        {
            if(bossRenderer.isVisible == false)
            {
                if(bossEntity.transform.position.y > this.transform.position.y)
                {
                    bossArrow.SetActive(true);
                }
            }
            else
            {
                bossArrow.SetActive(false);
            }
        }
        /*
        if (bossRenderer.enabled == true && bossRenderer.isVisible == false)
        {
            bossArrow.SetActive(true);
        }
        */
    }
}

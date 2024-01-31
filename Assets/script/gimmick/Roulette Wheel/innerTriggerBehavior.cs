using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innerTriggerBehavior : MonoBehaviour
{
    public GameObject Pinball;
    public GameObject funnels;
    public GameObject innerBarrier;
    public rouletteRimDashPanel[] dashPanels;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Pinball)
        {
            Pinball.layer = 0;
            funnels.SetActive(false);
            innerBarrier.SetActive(true);
            foreach(rouletteRimDashPanel panel in dashPanels)
            {
                panel.markerPassCount = 0;
            }
        }
    }
}

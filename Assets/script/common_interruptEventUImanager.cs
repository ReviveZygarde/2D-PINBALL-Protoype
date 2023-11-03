using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class common_interruptEventUImanager : MonoBehaviour
{
    //This is to properly restart the UI position transforms and all that stuff to its initial values if possible.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void resetBossInterruptBars()
    {
        GameObject tmp_UIbottomBars = GameObject.Find("int_b_barsBottom");
        GameObject tmp_UItopBars = GameObject.Find("int_b_barsTop");
        tmp_UIbottomBars.transform.localPosition = Vector2.zero;
        tmp_UItopBars.transform.localPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

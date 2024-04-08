using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bonust_wait : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitTimer());
    }

    IEnumerator waitTimer()
    {
        yield return new WaitForSeconds(2.5f);
        objectToEnable.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Scene_AutumnFoutain_ap_testing_granny_competitive");
    }
}

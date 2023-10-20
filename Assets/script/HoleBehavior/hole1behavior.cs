using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hole1behavior : MonoBehaviour
{
    public tableTally holeTally;
    private GameObject ballObject;
    private Collider2D triggerCollider;
    public Text statusText;

    //bool flags
    public bool isRegularHole1;
    public bool isRhythmMultiballHole2;
    public bool isBossHole3;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.Find("Pinball"); //Finds the pinball
        triggerCollider = GetComponent<Collider2D>(); //Gets its own collider
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>(); //Finds the status message box for the UI.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == ballObject)
        {
            ballObject.SetActive(false);
            StartCoroutine(cooldown());
        }
    }

    IEnumerator cooldown() //Timer-based wait time where the ball will shoot out. Maybe have a message displayed?
    {
        triggerCollider.enabled = false;
        holeTally.tallyHole1(this.gameObject); //Passes this GameObject into the method in common's TableTally
        statusText.text = "HOLE IN! +100";
        yield return new WaitForSeconds(1f);
        ballObject.SetActive(true); //Should spit the ball back out
        ballObject.transform.position = this.transform.position;
        yield return new WaitForSeconds(1f);
        triggerCollider.enabled = true;
        statusText.text = "";
        yield return null;
    }
}

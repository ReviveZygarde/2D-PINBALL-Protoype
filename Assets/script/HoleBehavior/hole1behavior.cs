using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole1behavior : MonoBehaviour
{
    public tableTally holeTally;
    private GameObject ballObject;
    private Collider2D triggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.Find("Pinball");
        triggerCollider = GetComponent<Collider2D>();
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

    IEnumerator cooldown()
    {
        triggerCollider.enabled = false;
        holeTally.tallyHole1();
        yield return new WaitForSeconds(1f);
        ballObject.SetActive(true); //Should spit the ball back out
        yield return new WaitForSeconds(1f);
        triggerCollider.enabled = true;
        yield return null;
    }
}

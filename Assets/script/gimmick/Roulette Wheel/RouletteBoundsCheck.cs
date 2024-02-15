using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBoundsCheck : MonoBehaviour
{
    [SerializeField] private GameObject Funnel;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pinball")
        {
            collision.gameObject.layer = 0;
            Funnel.SetActive(false);
        }
    }
}

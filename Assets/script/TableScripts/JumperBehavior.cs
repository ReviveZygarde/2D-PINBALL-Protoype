using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperBehavior : MonoBehaviour
{
    public tableTally tally;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tally.tallyBumper();
    }
}

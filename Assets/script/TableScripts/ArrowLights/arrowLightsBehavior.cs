using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowLightsBehavior : MonoBehaviour
{
    /// <summary>
    /// Based on State Machine and Criteria tallies for the hole entry, the arrows light up
    /// in corrspondence. I want to refrain from using Update constantly...
    /// this looks so ugly LMAFAOO
    /// </summary>

    private enum arrowType
    {BOSS, RUSH, RHYTHM}

    [SerializeField] private arrowType arrowForHole;

    //Lets try arrays
    [SerializeField] SpriteRenderer[] FirstEntryArrows;
    [SerializeField] SpriteRenderer[] SecondEntryArrows;
    [SerializeField] SpriteRenderer[] ThirdEntryArrows;

    private tableTally table;
    private ModeBehavior mode;

    // Start is called before the first frame update
    void Start()
    {
        GameObject common = GameObject.Find("common");
        table = common.GetComponent<tableTally>();
        mode = common.GetComponent<ModeBehavior>();
        deactivateAllLights();
        foreach (SpriteRenderer spriteRenderer in FirstEntryArrows)
        { spriteRenderer.color = Color.white; }
        if (arrowForHole == arrowType.BOSS)
        {
            StartCoroutine(lightCorrespondence_boss());
        }
        if (arrowForHole == arrowType.RHYTHM)
        {
            StartCoroutine(lightCorrespondence_rhythm());
        }
        if (arrowForHole == arrowType.RUSH)
        {
            StartCoroutine(lightCorrespondence_rush());
        }
    }

    private void OnEnable()
    {
        //this whole if thing should prevent the NullException every time the Scene starts.
        //The error happens because OnEnable is trying to access Mode first before Start can.
        if(mode != null)
        {
            deactivateAllLights();
            foreach (SpriteRenderer spriteRenderer in FirstEntryArrows)
            { spriteRenderer.color = Color.white; }
            if (arrowForHole == arrowType.BOSS)
            {
                StartCoroutine(lightCorrespondence_boss());
            }
            if (arrowForHole == arrowType.RHYTHM)
            {
                StartCoroutine(lightCorrespondence_rhythm());
            }
            if (arrowForHole == arrowType.RUSH)
            {
                StartCoroutine(lightCorrespondence_rush());
            }
        }
    }

    private void deactivateAllLights()
    {
        foreach (SpriteRenderer spriteRenderer in FirstEntryArrows)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = Color.black;
        }

        foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = Color.black;
        }

        foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = Color.black;
        }
    }

    private void turnOnAllLights()
    {
        foreach (SpriteRenderer spriteRenderer in FirstEntryArrows)
        {
            spriteRenderer.color = Color.white;
        }

        foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
        {
            spriteRenderer.color = Color.white;
        }

        foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
        {
            spriteRenderer.color = Color.white;
        }
    }

    IEnumerator lightCorrespondence_boss()
    {
        while(mode.modeState == ModeBehavior.currentMode.MODE_END)
        {
            Debug.Log("BOSS ARROWS On standby...");
            yield return new WaitForSecondsRealtime(1);
        }
        while(mode.modeState == ModeBehavior.currentMode.NORMAL)
        {
            if (table.criteria_hole3entry == 1)
            {
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.white; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.black; }
            }
            if (table.criteria_hole3entry == 2)
            {
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.white; }
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.white; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.black; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.white; }
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    IEnumerator lightCorrespondence_rhythm()
    {
        while (mode.modeState == ModeBehavior.currentMode.MODE_END)
        {
            Debug.Log("RHYTHM ARROWS On standby...");
            yield return new WaitForSecondsRealtime(1);
        }
        while (mode.modeState == ModeBehavior.currentMode.NORMAL)
        {
            if(table.criteria_hole2entry == 1)
            {
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.white; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.black; }
            }
            if(table.criteria_hole2entry == 2)
            {
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.white; }
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.white; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.black; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.white; }
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    IEnumerator lightCorrespondence_rush()
    {
        while (mode.modeState == ModeBehavior.currentMode.MODE_END)
        {
            Debug.Log("RUSH ARROWS On standby...");
            yield return new WaitForSecondsRealtime(1);
        }
        while (mode.modeState == ModeBehavior.currentMode.NORMAL)
        {
            if(table.criteria_ramp_entry == 1)
            {
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.white; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.black; }
            }
            if(table.criteria_ramp_entry == 2)
            {
                foreach (SpriteRenderer spriteRenderer in SecondEntryArrows)
                { spriteRenderer.color = Color.white; }
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.white; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.black; }
                yield return new WaitForSecondsRealtime(0.5f);
                foreach (SpriteRenderer spriteRenderer in ThirdEntryArrows)
                { spriteRenderer.color = Color.white; }
            }
            if(table.criteria_ramp_entry >= 3)
            {
                deactivateAllLights();
                yield return new WaitForSecondsRealtime(0.5f);
                turnOnAllLights();
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }

        while (mode.modeState == ModeBehavior.currentMode.RUSH)
        {
            deactivateAllLights();
            yield return new WaitForSecondsRealtime(0.5f);
            turnOnAllLights();
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mode.modeState == ModeBehavior.currentMode.MODE_END)
        {
            deactivateAllLights();
            foreach (SpriteRenderer spriteRenderer in FirstEntryArrows)
            { spriteRenderer.color = Color.white; }
            StopAllCoroutines();
            this.enabled = false;
        }
        if (mode.modeState == ModeBehavior.currentMode.BOSS || mode.modeState == ModeBehavior.currentMode.RHYTHM)
        {
            if(arrowForHole == arrowType.BOSS || arrowForHole == arrowType.RHYTHM)
            {
                turnOnAllLights();
            }
        }
    }
}

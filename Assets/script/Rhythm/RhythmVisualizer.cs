using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Rhythm Program made by Mack Pearson-Muggli.
/// Used with permission.
/// </summary>

public class RhythmVisualizer : MonoBehaviour
{
    [SerializeField]
    GameObject imageObj, textObj;
    Image image;
    TMPro.TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        image = imageObj.GetComponent<Image>();
        textMeshPro = textObj.GetComponent<TMPro.TextMeshProUGUI>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (RhythmManager.Instance.IsOnBeat())
            {
                textMeshPro.text = "Good";
            }
            if (!RhythmManager.Instance.IsOnBeat())
            {
                textMeshPro.text = "Bad";
            }
        }
        changeSquareColor();
        /*else if (!SongPlayer.Instance.IsOnBeat())
        {
            image.color = Color.white;
        }*/
    }



    void changeSquareColor()
    {
        if (RhythmManager.Instance.IsOnBeat())
        {
            image.color = Color.green;
        }
        if (!RhythmManager.Instance.IsOnBeat())
        {
            image.color = Color.red;
        }
    }
}
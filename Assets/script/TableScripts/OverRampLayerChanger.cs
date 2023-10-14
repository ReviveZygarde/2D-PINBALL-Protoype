using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverRampLayerChanger : MonoBehaviour
{
    public GameObject Pinball;
    private Rigidbody2D ballRigidbody;
    public bool isEntrance;
    public bool isExit;
    public int LayerToSetPinball;
    public int OriginalLayerToSetPinball;
    public Transform BallDirection;
    private float magnitude_forRB;

    // Start is called before the first frame update
    void Start()
    {
        if (isEntrance)
        {
            ballRigidbody = Pinball.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            if (isEntrance)
            {
                Pinball.transform.position = this.transform.position;
                Pinball.transform.rotation = BallDirection.rotation;
                Pinball.layer = LayerToSetPinball;
                Debug.Log($"Pinball layer is now {Pinball.layer}.");
                ballRigidbody.AddForce(Vector2.one * magnitude_forRB, ForceMode2D.Impulse);

            }
            if (isExit)
            {
                Pinball.layer = OriginalLayerToSetPinball;
                Debug.Log($"Pinball layer is now {Pinball.layer}.");
            }
        }
    }
}

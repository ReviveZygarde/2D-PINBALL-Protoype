using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverRampLayerChanger : MonoBehaviour
{
    public GameObject Pinball;
    private Rigidbody2D ballRigidbody;
    [Tooltip("Marks the OverRamp's entrance so the ball can change its Collision Layer")]
    public bool isEntrance;
    [Tooltip("Marks the OverRamp's entrance so the ball can change back to its original Collision Layer")]
    public bool isExit;
    [Tooltip("Set the ball to a certain Layer defined by the designer.")]
    public int LayerToSetPinball;
    [Tooltip("Set the ball back to its previous Layer defined by the designer. Recommended value: 0")]
    public int OriginalLayerToSetPinball;
    [Tooltip("The direction you want the ball to go to. You can select any GameObject and it will use the Rotation of that object to set the ball's respectively.")]
    public Transform BallDirection;
    [Tooltip("How fast you want the ball Velocity to be. Recommended value: 20. If you don't want to change it's speed, set it to 1.")]
    public int velocityMultiplier;

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
                ballRigidbody.velocity = Vector2.one * velocityMultiplier;

            }
            if (isExit)
            {
                Pinball.layer = OriginalLayerToSetPinball;
                Debug.Log($"Pinball layer is now {Pinball.layer}.");
            }
        }
    }
}

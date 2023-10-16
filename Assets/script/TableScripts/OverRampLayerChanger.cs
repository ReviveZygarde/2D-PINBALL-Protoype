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

    [Tooltip("Makes the ball's velocity come to a full stop (zero) when it exits the ramp, to simulate the ball falling back onto the table instead of rolling out. Only applies if IsExit is ON.")]
    public bool fakeElevation;

    [Tooltip("Set the ball to a certain Layer defined by the designer. Recommended value: 6. If splitting the ramp into mutiple sections, set it to the layer you assigned the section to.")]
    public int LayerToSetPinball;

    [Tooltip("Set the ball back to its original Layer defined by the designer. Recommended value: 0. Only used if IsExit is ON.")]
    public int OriginalLayerToSetPinball;

    [Tooltip("Direction you want the ball to go." +
        "\nExamples:" +
        "\n0 , 1 to shoot the ball straight up" +
        "\n1, 1 to make the go right, diagonally" +
        "\n-1, 1 to make the go left, diagonally" +
        "\netc..." +
        "\nIf FakeElevation is ON, leave this at (0,0).")]
    public Vector2 ballDirection;

    [Tooltip("How fast you want the ball Velocity to be. Recommended value: 20. Only used if IsEntrance is ON.")]
    public int velocityMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = Pinball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            if (isEntrance)
            {
                Pinball.transform.position = this.transform.position;
                Pinball.layer = LayerToSetPinball;
                Debug.Log($"Pinball layer is now {Pinball.layer}.");
                ballRigidbody.velocity = ballDirection * velocityMultiplier;

            }
            if (isExit)
            {
                Pinball.layer = OriginalLayerToSetPinball;
                Debug.Log($"Pinball layer is now {Pinball.layer}.");
                if (fakeElevation)
                {
                    ballRigidbody.velocity = ballDirection * 0;
                }
            }
        }
    }
}

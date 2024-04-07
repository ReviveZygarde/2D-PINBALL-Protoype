using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



//Got from the video https://www.youtube.com/watch?v=f3IYIvd-1mY

public partial class PlayerStateManager
{
    private void OnMovement(InputValue value)
    {
        InputVector = value.Get<Vector2>();
        MoveVector.x = InputVector.x;
        MoveVector.z = InputVector.y;

        // Debug.Log($"X move: (MoveVetor.x)");
        //Debug.Log($"Z move: (MoveVector.z)");
    }

    private void OnTricks(InputValue value)
    {
        Vector2 TrickVector = value.Get<Vector2>();
    }
}

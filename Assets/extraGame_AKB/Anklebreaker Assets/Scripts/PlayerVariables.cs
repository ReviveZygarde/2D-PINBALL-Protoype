using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Got from the video https://www.youtube.com/watch?v=f3IYIvd-1mY

public partial class PlayerStateManager
{
    public CharacterController Controller;

    public PlayerInput Input;

    //Sets player movement each frame
    public Vector3 MoveVector;

    //Sets for X axis and Y axis
    public Vector2 InputVector;

    //Speed of the Player
    public float PlayerSpeed;

    //Rotation Speed
    public float PlayerRotateSpeed;

    private Vector3 _gravityVector;
}

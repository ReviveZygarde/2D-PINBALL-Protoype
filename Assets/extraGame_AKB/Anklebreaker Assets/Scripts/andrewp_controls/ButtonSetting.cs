using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSetting : MonoBehaviour
{
    private PlayerInput pl_input;
    private PlayerStateManager psm;
    public Animator animator;


    private void Awake()
    {
        pl_input = GetComponent<PlayerInput>();
        psm = GetComponent<PlayerStateManager>();
    }

    void OnShoot()
    {
        psm.ShootBall();
        Debug.Log("AP DEBUG: The shoot button has been pushed.");
    }

    void OnPauseButton()
    {
        psm.PauseGame();
        Debug.Log("AP DEBUG: The pause button has been pushed.");
    }

    void OnSteal()
    {
        psm.StealBall();
    }

    void OnDefense()
    {
        psm.DefendBall();
    }

    void OnSpAction()
    {
        psm.performSPAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rouletteDisabler : MonoBehaviour
{
    private PlayerInput pl_input;
    [Tooltip("Bandaid fix for ball getting stuck in roulette bug")]
    public bool isRouletteInScene;
    [SerializeField] private GameObject rouletteFunnelForCasinoStage;

    // Start is called before the first frame update
    void Start()
    {
        pl_input = GetComponent<PlayerInput>();
    }

    void OnBoardShake_Up(InputValue value)
    {
        disableRouletteFunnels();
    }

    void OnBoardShake_L(InputValue value)
    {
        disableRouletteFunnels();
    }

    void OnBoardShake_R(InputValue value)
    {
        disableRouletteFunnels();
    }

    void disableRouletteFunnels()
    {
        if (rouletteFunnelForCasinoStage != null)
        {
            rouletteFunnelForCasinoStage.SetActive(false);
        }
    }
}

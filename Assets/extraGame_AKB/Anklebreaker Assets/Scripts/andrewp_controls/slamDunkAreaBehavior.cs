using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slamDunkAreaBehavior : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private PlayerStateManager currentPlayer_psm;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //player = other.gameObject;
            currentPlayer_psm = player.GetComponent<PlayerStateManager>();
            currentPlayer_psm.isInSDarea = true;
            if(currentPlayer_psm.status == PlayerStateManager.playerStatus.SP_READY && currentPlayer_psm.hasBall)
            {
                currentPlayer_psm.B_ButtonPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            //player = other.gameObject;
            currentPlayer_psm = player.GetComponent<PlayerStateManager>();
            currentPlayer_psm.isInSDarea = false;
            if (currentPlayer_psm.status == PlayerStateManager.playerStatus.SP_READY && currentPlayer_psm.hasBall)
            {
                currentPlayer_psm.B_ButtonPrompt.SetActive(false);
            }
        }
    }
}

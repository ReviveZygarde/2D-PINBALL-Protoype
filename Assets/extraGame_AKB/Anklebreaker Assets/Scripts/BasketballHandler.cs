using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BasketballHandler : MonoBehaviour
{
    public bool hasBall;
    private Transform playerHand;
    private GameObject player;
    private GameObject attachPoint;
    private MeshCollider Court;
    private PlayerStateManager currentPlayer_psm;
    private SphereCollider ball_coll;

    [SerializeField] private Transform originalSpawn;
    [SerializeField] private int respawnWaitTime;

    [SerializeField]
    private Transform _target;
    private Rigidbody _rb;

    [SerializeField]
    float initialAngle, scoreDistance, maxXFailure, maxYFailure, maxZFailure,  threeChance, twoChance;
    Vector3 initialPos;

    public bool shotEntered;
    bool animAlreadyPlayed; //This is the spam proof boolean flag so that methods dont get replayed again when the player does certain actions.
    public bool onAwayTeam; // Checks what Team the Player is on.

    int scoreToAdd;
    public Animator anim;
    private GameObject ballTrail;
    [SerializeField]
    public enum ballState //Why tf am i using a bunch of booleans when i could have easily done this, i'm a dumbass
    {OPEN, TAKEN, THROWN, DROPPED_BY_OFFENSE, PROTECTED}
    public ballState status = ballState.OPEN;

    // Start is called before the first frame update
    void Start()
    {
        hasBall = false;
        ball_coll = GetComponent<SphereCollider>();
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
        GameObject Court_gameObject = GameObject.Find("Court");
        Court = Court_gameObject.GetComponent<MeshCollider>();
        player = GameObject.FindWithTag("Player");
        ballTrail = this.gameObject.transform.Find("Trail").gameObject;
        ballTrail.SetActive(false);
        onAwayTeam = player.GetComponent<PlayerStateManager>().awayTeam;
    }

    // Update is called once per frame
    void Update()
    {
        checkProtectedStatus();
        /*
        if(status == ballState.OPEN && _rb.isKinematic)
        {
            Debug.Log("AP DEBUG : The ball is open but Kinematic is left ON! Oh MY GOD!!");
        }
        */
    }

    private void checkProtectedStatus()
    {
        if(status == ballState.PROTECTED)
        {
            if(currentPlayer_psm.status == PlayerStateManager.playerStatus.IN_DEFENSE)
             {
            FindRightHand();
            }
        }
        else
        {
            return;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||other.gameObject.CompareTag("Player2") ) 
        {
            player = other.gameObject;
            currentPlayer_psm = player.GetComponent<PlayerStateManager>();
            if (status == ballState.TAKEN || status == ballState.THROWN || currentPlayer_psm.status == PlayerStateManager.playerStatus.OFFENDED)
            {
                return; //Stops the method immediately because the ball is currently
                        //in use by another player. This is to prevent multiple players
                        //having a hasBall param, which makes the ball teleport to
                        //different players if they decide to Shoot.
            }
            if (currentPlayer_psm.awayTeam)
            {
                onAwayTeam = true;
            }
            else
            {
                onAwayTeam = false;
            }
            ballTrail.SetActive(false); //Turns off the ball's trail.
            currentPlayer_psm.hasBall = true;
            WhoHasBall();
            //Connects to player's Animator to play Dribble Animation
            Animator playerAnims = player.GetComponent<Animator>();
            attachPoint = player.transform.Find("AttachPoint").gameObject;
            FindRightHand(); //Goes through the WHOOOOOOOOOOOOOOOOLE hirarchy in the Player prefab to find the hand_r Transform. Is this really the only way? maybe i can do a foreach instead.
            this.gameObject.GetComponent<CamerCloseAndFar>().Switch_Cameras(false);
            //---Tellopenhasball
            hasBall = true;
            status = ballState.TAKEN;
            Debug.Log("AP DEBUG: ball state is set from Open -> taken.");
            playerAnims.SetBool("hasBall", true);
            //Debug to tell who has the ball
            Debug.Log($"{player} has the ball");

            //Attaches Ball to Player
            _rb.isKinematic = true; //Keep Kinematic property on ONLY when it is attached to the player!!!!
            shotEntered = false;
            if (!animAlreadyPlayed) //To make sure the animator doesnt get played again when shooting the ball.
            {
                    anim.enabled = true;
                    animAlreadyPlayed = true;
                    transform.localPosition = Vector3.zero;
                    this.gameObject.transform.SetParent(attachPoint.transform);
            }
            }
            if (other.gameObject.CompareTag("EntryCheck"))
            {
                if (onAwayTeam)
                {
                    GameManager.Instance.scoreP2 += scoreToAdd;
                    //GameManager.Instance.Score_player_one(scoreToAdd);
                    Debug.Log($"Player 2 scored, Score: {GameManager.Instance.scoreP2}");
                    StartCoroutine(ResetBall());
                this.gameObject.GetComponent<AudioScoreBehavior>().PlaySoundScore();
                }
                else if (!onAwayTeam)
                {
                    GameManager.Instance.scoreP1 += scoreToAdd;
                    //GameManager.Instance.Score_player_two(scoreToAdd);
                    Debug.Log($"Player 1 scored, Score: {GameManager.Instance.scoreP1}");
                    StartCoroutine(ResetBall());
                    this.gameObject.GetComponent<AudioScoreBehavior>().PlaySoundScore();
            }
                shotEntered = true;
                ballTrail.SetActive(false);
            }
            if (other.gameObject.CompareTag("ExitCheck"))
            {
                if (shotEntered)
                {
                    //GameManager.Instance.score += scoreToAdd;
                    //Debug.Log($"Player scored, Score: {GameManager.Instance.score}");
                    StartCoroutine(ResetBall());
                    this.gameObject.GetComponent<AudioScoreBehavior>().PlaySoundMissed();
            }
                shotEntered = false;
                ballTrail.SetActive(false);
            }

    }

    public void FindRightHand()
    {
        Transform temp = player.transform.Find("r_hand_shadowcopy");
        playerHand = temp;
        transform.position = playerHand.position;
    }

    public void WhoHasBall()
    {
        //Checks and see who has the bal
        if(onAwayTeam == true)
        {
            //If on Away team, change hoop target
            _target = GameObject.Find("Away_Target").transform;
            
        }
        else
        {
            _target = GameObject.Find("Home_Target").transform;
            
        }
    }

    public void ForceChangeParentToPlayerHand() //This method disables the Animator component for the ball and changes its parent to the player's hand instead of the Attach Point. ONLY FOR SHOOTING THE BALL
    {
        anim.enabled = false;
        this.gameObject.transform.SetParent(playerHand.transform);
        transform.localPosition = Vector3.zero;
    }

    public void ShootBall()
    {
        if (!hasBall) return;
        //Shoots the ball
        this.gameObject.GetComponent<CamerCloseAndFar>().Switch_Cameras(true);
        //---Tellopenhasnotball
        hasBall = false;
        ForceChangeParentToPlayerHand();
        _rb.isKinematic = false;
        transform.SetParent(null);
        Launch(CalculateTarget());
        status = ballState.THROWN;
        StartCoroutine(changeBallState());
        Debug.Log($"{player} has shot the ball");
        currentPlayer_psm.hasBall = false;
        currentPlayer_psm.SpecialGaugeValue = currentPlayer_psm.SpecialGaugeValue + currentPlayer_psm.SP_GaugeIncreaseValue;
        currentPlayer_psm = null; //Nulls the current playerStateManager because now it does not belong to anyone.
        ball_coll.enabled = true;
    }

    IEnumerator changeBallState() //The good old switch, case, break State machine method. These are lovely.
    {
        //ball_coll.enabled = false;
        yield return new WaitForSeconds(0.3f);
        switch (status)
        {
            case ballState.THROWN:
                status = ballState.OPEN;
                Debug.Log("AP DEBUG: ball state is set from Thrown -> Open.");
                break;
            case ballState.DROPPED_BY_OFFENSE:
                status = ballState.OPEN;
                Debug.Log("AP DEBUG: ball state is set from Dropped by offense -> Open.");
                break;
        }
    }

    Vector3 CalculateTarget()
    {
        Vector3 target = _target.position;

        Vector3 planarTarget = new Vector3(target.x, 0, target.z);
        Vector3 planarPosition = new Vector3(transform.position.x, 0, transform.position.z);

        float distance = Vector3.Distance(planarTarget, planarPosition);

        if (distance > scoreDistance && Random.Range(0f, 1f) > threeChance || 
            distance < scoreDistance && Random.Range(0f, 1f) > twoChance)
        {
            target += Vector3.forward * Random.Range(-maxZFailure, maxZFailure);
            target += Vector3.right * Random.Range(-maxXFailure, maxXFailure);
            target += Vector3.up * Random.Range(-maxYFailure, maxYFailure);
        }
        
        return target;
    }

    void Launch(Vector3 targetPos)
    {
        ballTrail.SetActive(true);
        initialPos = transform.position;

        float gravity = Physics.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 planarTarget = new Vector3(targetPos.x, 0, targetPos.z);
        Vector3 planarPosition = new Vector3(initialPos.x, 0, initialPos.z);

        float distance = Vector3.Distance(planarTarget, planarPosition);
        float yOffset = initialPos.y - targetPos.y;

        if (distance > scoreDistance)
        {
            scoreToAdd = 3;
        }
        else
        {
            scoreToAdd = 2;
        }

        // Original equation https://physics.stackexchange.com/questions/27992/solving-for-initial-velocity-required-to-launch-a-projectile-to-a-given-destinat?rq=1
        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPosition);
        if (targetPos.x < initialPos.x) angleBetweenObjects *= -1;
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        _rb.useGravity = true;
        _rb.velocity = finalVelocity;
        StartCoroutine(changeSpamproofBool()); //resets the animAlreadyPlayed boolean to false
    }

    IEnumerator changeSpamproofBool()
    {
        yield return new WaitForSeconds(0.2f); //The reason why the ball gets stuck in mid air is because this wait time was too long... leaving the bool True.
        animAlreadyPlayed = false;
    }


    public void SetParent(GameObject newParent) 
    {
        //Sets the Game Object as a child to the object it want to be parented
        playerHand.transform.parent = newParent.transform;
        //Console Check
        Debug.Log("Player's Parent: " + playerHand.transform.parent.name);
    }

    public void DetachFromParent() 
    {
        //Detaches ball from Player's hand
        if (hasBall == false) 
        {
            transform.parent = null;
        }
       
    }

    IEnumerator ResetBall() 
    {
        if (shotEntered) 
        {
            yield return new WaitForSeconds(respawnWaitTime);
            this.transform.position = originalSpawn.position;
        }
    
    }

    public void ReleaseFromPlayerHand() //How can I make the ball not stay underground? And how can I make the ball not float if I manually place it above the ground despite the rigidbody being active?
    {
        anim.enabled = false;
        ForceChangeParentToPlayerHand();
        //transform.position = attachPoint.transform.position;
        if(currentPlayer_psm.status == PlayerStateManager.playerStatus.IN_SP_ACTION)
        {
            Debug.Log("AP DEBUG : in sp action, dopping ball from the hoop.");
            transform.position = new Vector3(transform.position.x, -8.674677f, transform.position.z);
        }
        else
        {
            Debug.Log("AP DEBUG : Not in sp action, dopping ball normally.");
            transform.position = new Vector3(transform.position.x, 2.84f, transform.position.z);
            status = ballState.DROPPED_BY_OFFENSE;
            Debug.Log("AP DEBUG: ball state is Dropped by offense");
        }
        transform.parent = null;
        _rb.useGravity = true; //Do I need to use this again?
        _rb.isKinematic = false; //This is so the ball actually falls and does not defy gravity.
        hasBall = false;
        attachPoint = null;
        animAlreadyPlayed = false;
        onAwayTeam = false;
    }

}

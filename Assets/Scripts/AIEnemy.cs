using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public GameObject pickupobject;
    //ai line of sight
    public bool playerinLOS = false;
    public float fieldOfViewA = 160f; //angle
    public float LOSradius = 45f;

    //ai sight and memory 
    private bool aiPlayer = false;
    public float memoryStart = 10f;
    private float increMemory;

    //ai hearing 
    Vector3 noisePosition;
    private bool aiheard = false;
    public float noiseDistance = 0f;
    public float spinSpeed = 3f;
    private bool canSpin = false;
    private float isSpinning;
    public float spinTime = 3f;

    //patrol points
    public Transform[] movepoint;
    private int randompoint;

    private float waitTime;
    public float startWaitTime = 1f;

    NavMeshAgent nav;
    public float distToPlayer = 5.0f;

    private float randomStrafeStart;
    private float waitStrafeTime;
    public float t_minStrafe;
    public float t_maxStrafe;

    public Transform strafeRight;
    public Transform strafeLeft;
    private int randomStrafeDir;

    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randompoint = Random.Range(0, movepoint.Length);
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(PlayerMovement.playerPosition, transform.position); //check position between player and enemy
        if(distance <= LOSradius)
        {
            CheckLOS();
        }

        if (nav.isActiveAndEnabled)
        {
            if (playerinLOS == false && aiPlayer == false && aiheard == false)
            {
                Patrol();
                NoiseCheck();
                StopCoroutine(AiMemory());
            }

            else if (aiheard == true && playerinLOS == false && aiPlayer == false)
            {
                canSpin = true;
                GoToNoisePosition();
            }
            else if (playerinLOS == true)
            {
                facePlayer();
                ChasePlayer();
            }
            else if (aiPlayer == true && playerinLOS == false)
            {
                ChasePlayer();
                StartCoroutine(AiMemory());
            }
        }
    }

    void Patrol()
    {
            nav.SetDestination(movepoint[randompoint].position);

            if (Vector3.Distance(transform.position, movepoint[randompoint].position) < 2.0f)
            {
                if (waitTime <= 0)
                {
                    randompoint = Random.Range(0, movepoint.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
    }

    void ChasePlayer()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPosition, transform.position);

        if(distance <= chaseRadius && distance >distToPlayer)
        {
            nav.SetDestination(PlayerMovement.playerPosition);
        }
        else if (nav.isActiveAndEnabled && distance <= distToPlayer)
        {
            randomStrafeDir = Random.Range(0, 2);
            randomStrafeStart = Random.Range(t_minStrafe, t_maxStrafe);

            if(waitStrafeTime <= 0)
            {
                if(randomStrafeDir ==0)
                {
                    nav.SetDestination(strafeLeft.position);
                }
                else if (randomStrafeDir == 1)
                {
                    nav.SetDestination(strafeRight.position);
                }
                waitStrafeTime = randomStrafeStart;
            }
            else
            {
                waitStrafeTime -= Time.deltaTime;
            }
        }
    }

    void facePlayer()
    {
        Vector3 direction = (PlayerMovement.playerPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
    }

    void NoiseCheck()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPosition, transform.position);

        
        
            if (Input.GetButton("Fire1"))
            {
                noisePosition = PlayerMovement.playerPosition;
                aiheard = true;
            }
            else
            {
                aiheard = false;
                canSpin = false;
            }
        
        
    }
    void GoToNoisePosition()
    {
        nav.SetDestination(noisePosition);
        if (Vector3.Distance(transform.position, noisePosition)<= 5f && canSpin == true)
        {
            isSpinning += Time.deltaTime;
            transform.Rotate(Vector3.up * spinSpeed, Space.World);

            if (isSpinning >= spinTime)
            {
                canSpin = false;
                aiheard = false;
                isSpinning = 0f;
            }
        }
    }

    IEnumerator AiMemory()
    {
        increMemory = 0f;
        while(increMemory < memoryStart)
        {
            increMemory += Time.deltaTime;
            aiPlayer = true;
            yield return null;
        }
        aiheard = false;
        aiPlayer = false;
    }
    void CheckLOS()
    {
        Vector3 direction = PlayerMovement.playerPosition - transform.position;

        float angle = Vector3.Angle(direction, transform.forward);

        if(angle < fieldOfViewA *0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction.normalized, out hit, LOSradius))
            {
                if (hit.collider.tag == "Player")
                {
                    playerinLOS = true;
                    aiPlayer = true;
                }
                else
                {
                    playerinLOS = false;
                }
            }
        }
    }

}


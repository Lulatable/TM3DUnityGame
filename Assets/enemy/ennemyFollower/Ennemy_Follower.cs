using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class Ennemy_Follower : MonoBehaviour
{
    // Start is called before the first frame update

    public float distance;
    public float speed;
    private Rigidbody rb;
    public Transform player;
    public Transform ennemy;
    private NavMeshAgent agent;
    public Field_Of_View fov;
    public Field_Of_Attack foa;
    public Health healthManager;
    private long attackTick;
    private Vector3 _targetPos;
    private Vector3 _finalTargetPos;
    public Animator animator;
    float timer;
    int staytime;
    public Health_ennemy health;
    bool countdeath;
    bool isAttacking;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // To smooth out the movement of the rigidbody between frames
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        // So that the character doesn't collapse
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        agent = GetComponent<NavMeshAgent>();
        _finalTargetPos = getRandompos();
        animator = GetComponent<Animator>();
        health = GetComponent<Health_ennemy>();
        
        countdeath = false;
        
    }
    private float countNotWalking = 0;
    // Update is called once per frame
    void Update()
    {
        if (health.isdead)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
               countdeath = true;
            }
            else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && countdeath)
            {
                Destroy(gameObject);
            }
        }
        else 
        {
            if ((!fov.canSeePlayer && !foa.canAttackPlayer) || staytime > 6)
            {
                if (agent.remainingDistance <= agent.stoppingDistance && timer <= 3)
                {
                    print("idle");
                    timer += Time.deltaTime;
                    agent.speed = 0;
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                    {
                        animator.SetTrigger("idle");
                    }
                        
                }
               
                else if (agent.remainingDistance <= agent.stoppingDistance && timer > 3)
                {
                    print("new target");
                    agent.speed = speed;
                    _finalTargetPos = getRandompos();
                    agent.destination = _finalTargetPos;
                    
                }
                else if (agent.speed > 0.5)
                {
                    print("speed");
                    timer = 0;
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
                    {
                        animator.SetTrigger("walk");
                    }
                }


                staytime = 0;
                
                //animator.SetBool("walking", false);
                timer += Time.deltaTime;
                
                
                //if (agent.remainingDistance - agent.stoppingDistance < 0.01)
               // {
                    
                   // countNotWalking = 0.0f;
                  //  if(animator.GetBool("walking"))
                    //{
                        //animator.SetBool("walking", false);
                   // }
                //} else if(!animator.GetBool("walking") && countNotWalking > 1.5f)
                //if (agent.remainingDistance > agent.stoppingDistance)
                //{
                    //print("Start walking");
                   // countNotWalking = 0.0f;
                  //  animator.SetBool("walking", true);
               // } else
                //{
                  //  countNotWalking += Time.deltaTime;
                //}
                
                
            }
            else if (fov.canSeePlayer || staytime < 6)
            {


                animator.SetTrigger("run");
                agent.speed = speed * 2;
                agent.destination = player.position;
                if (!fov.canSeePlayer)
                {
                    staytime += 1;
                }
                
            }
            if (foa.canAttackPlayer && (attackTick == 0 || System.DateTime.Now.Ticks - attackTick > 10000000))
            {
                animator.SetTrigger("attack");
                
                //healthManager.currentHealth = healthManager.currentHealth - 25;

                // a vérifier ,pas sûre
                attackTick = System.DateTime.Now.Ticks;

            }

        }


    }
    IEnumerator waiter(int a, int b)
    {
        int wait_time = Random.Range(a, b);
        yield return new WaitForSeconds(wait_time);
    }
    public Vector3 getRandompos()
    {
        _targetPos = Random.insideUnitCircle * distance;
        Vector3 koko = new Vector3(_targetPos.x,0,_targetPos.y);
        NavMeshHit hit;
        NavMesh.SamplePosition(koko, out hit, distance, 1);
        return hit.position;
    }
}

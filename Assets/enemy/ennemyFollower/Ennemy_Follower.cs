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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _finalTargetPos = getRandompos();
        animator = GetComponent<Animator>();
        health = GetComponent<Health_ennemy>();
        animator.SetBool("walking", false);
        countdeath = false;
        
    }

    // Update is called once per frame
    void Update()
    {;
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
            if (!fov.canSeePlayer && !foa.canAttackPlayer)
            {
                timer += Time.deltaTime;
                if (agent.remainingDistance <= agent.stoppingDistance && timer > 5)
                {

                    animator.SetBool("walking", true);
                    _finalTargetPos = getRandompos();

                    agent.destination = _finalTargetPos;
                }
            }
            if (fov.canSeePlayer || staytime < 7)
            {
                agent.destination = player.position;
                staytime += 1;
            }
            if (foa.canAttackPlayer && (attackTick == 0 || System.DateTime.Now.Ticks - attackTick > 10000000))
            {
                animator.SetTrigger("attack");
                healthManager.currentHealth = healthManager.currentHealth - 25;

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

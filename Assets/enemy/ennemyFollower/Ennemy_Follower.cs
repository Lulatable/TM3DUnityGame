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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _finalTargetPos = getRandompos();
        animator = GetComponent<Animator>();
        animator.SetBool("walking", true);
        
    }

    // Update is called once per frame
    void Update()
    {;
        if (!fov.canSeePlayer && !foa.canAttackPlayer) 
        {
            
            if (agent.remainingDistance <= agent.stoppingDistance) 
            {
               
                _finalTargetPos = getRandompos();
                
                agent.destination = _finalTargetPos;
            }
        }
        if (fov.canSeePlayer)  
        {
             agent.destination = player.position;
        }
        if (foa.canAttackPlayer && ( attackTick ==0 || System.DateTime.Now.Ticks - attackTick > 10000000))
        {
            animator.SetTrigger("attack");
            healthManager.currentHealth = healthManager.currentHealth - 25;

            // a vérifier ,pas sûre
            attackTick = System.DateTime.Now.Ticks;

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

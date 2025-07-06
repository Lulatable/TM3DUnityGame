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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _finalTargetPos = getRandompos();
    }

    // Update is called once per frame
    void Update()
    {;
        if (!fov.canSeePlayer || !foa.canAttackPlayer) 
        {

            agent.destination = _finalTargetPos;
            if ((ennemy.transform.position - _targetPos).sqrMagnitude > 0.01f) 
            {
                _finalTargetPos = getRandompos();
            }
        }
        if (fov.canSeePlayer)  
        {
             agent.destination = player.position;
        }
        if (foa.canAttackPlayer && ( attackTick ==0 || System.DateTime.Now.Ticks - attackTick > 10000000))
        {
            healthManager.currentHealth = healthManager.currentHealth - 25;
            // a vérifier ,pas sûre
            attackTick = System.DateTime.Now.Ticks;
        }

       
    }
    public Vector3 getRandompos()
    {
        _targetPos = Random.insideUnitCircle * distance;
        NavMeshHit hit;
        NavMesh.SamplePosition(_targetPos, out hit, distance, 1);
        return hit.position;
    }
}

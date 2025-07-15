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
        if (!fov.canSeePlayer && !foa.canAttackPlayer) 
        {

            agent.destination = _finalTargetPos;
            if ((ennemy.transform.position - _finalTargetPos).sqrMagnitude > 0.01f) 
            {
               // _finalTargetPos = getRandompos();
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
        Vector3 koko = new Vector3(_targetPos.x,0,_targetPos.y);
        NavMeshHit hit;
        NavMesh.SamplePosition(koko, out hit, distance, 1);
        print(hit.position);
        return hit.position;
    }
}

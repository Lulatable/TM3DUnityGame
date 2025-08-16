using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemy_angel : MonoBehaviour
{
    private NavMeshAgent agent;
    public Camera playercam;
    public int fog_distance;
    public float speed , catchDistance;
    public Transform player;
    public Health healthPlayer;
    public GameObject bodymesh;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playercam);
        float distance = Vector3.Distance(transform.position,player.position);
        if (GeometryUtility.TestPlanesAABB(planes, bodymesh.GetComponent<Renderer>().bounds))
        {
            agent.speed = 0;
            animator.speed = 0;
            animator.SetBool("Run", true);
            agent.SetDestination(transform.position);
            
        }
        else if (!GeometryUtility.TestPlanesAABB(planes,bodymesh.GetComponent<Renderer>().bounds))
        {
            agent.speed = speed;
            animator.speed = 1;
            agent.destination = player.position;

            if (distance <= catchDistance)
            {
                
                healthPlayer.currentHealth = 0;
            }
        }
        
    }
}

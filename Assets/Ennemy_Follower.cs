using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Ennemy_Follower : MonoBehaviour
{
    // Start is called before the first frame update

    public float distance;

    public Transform player;
    private NavMeshAgent agent;
    public Field_Of_View fov;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();       
    }

    // Update is called once per frame
    void Update()
    {;
        if (fov.canSeePlayer)  
        {
            agent.destination = player.position;
        }
       
    }
}

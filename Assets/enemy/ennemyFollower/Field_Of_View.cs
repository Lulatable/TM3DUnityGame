using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_Of_View : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef ;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     // permet d'appeler la fonction avec un intervalle choisi
    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
     // créer un collider cercle autour de l'ennemi qui vérifie s'il y a le joueur
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            //récupère la position du jouer et calcule la direction jusqu'au joueur
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            // vérifie s'il est dans l'arc de cercle créer avec l'angle
            if(Vector3.Angle(transform.forward,directionToTarget) < angle /2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                // crée un faisceau de l'ennemi au joueur qui est arreté par les obstacle
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else canSeePlayer = false;  
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if(canSeePlayer)
        {
          canSeePlayer = false;
        }
    }
}

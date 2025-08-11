using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class axe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Health_ennemy health = other.GetComponent<Health_ennemy>();
        Animator ennemy = other.GetComponent<Animator>();
        if (health)
        {
            if (variableManager.instance.CanAttack)
            {
                health.currentHealth -= 25;
                ennemy.SetTrigger("hit");
            }
        }
    }
}

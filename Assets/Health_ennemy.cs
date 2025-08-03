using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health_ennemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentHealth;
    public float maxhealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }

        if (variableManager.instance.CanAttack && variableManager.instance.ShortAttack)
        {
            currentHealth = currentHealth - 50;
            // a vérifier ,pas sûre
            
        }
    }
}

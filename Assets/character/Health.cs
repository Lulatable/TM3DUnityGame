using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxhealth;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        variableManager.instance.isDying = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
      if (currentHealth == 0)
        {
            variableManager.instance.isDying = true;    
        }
    }
}

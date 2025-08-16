using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health_ennemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentHealth;
    public float maxhealth;
    public Animator animator;
    public bool isdead;
    void Start()
    {
        animator = GetComponent<Animator>();
        isdead = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
        if (currentHealth == 0)
        {
            isdead = true;
            animator.SetTrigger("Death");
        }

    }
}

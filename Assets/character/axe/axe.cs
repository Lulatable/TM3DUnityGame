using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class axe : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public float spinrate;
    public bool isfloating;
    public GameObject camera_follow;
    float rotationX = 0f;
    float rotationY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        rotationY += camera_follow.transform.rotation.y;
        rotationX += camera_follow.transform.rotation.x;

        if (variableManager.instance.LongAttackThrow)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(rotationX, rotationY, 0), ForceMode.Impulse);
            rb.AddTorque(new Vector3(spinrate,0,0), ForceMode.Impulse);
            isfloating = true;
            variableManager.instance.LongAttackThrow = false;

        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        Health_ennemy health = other.GetComponent<Health_ennemy>();
        Animator ennemy = other.GetComponent<Animator>();
        if (health)
        {
            if (variableManager.instance.CanAttack || isfloating)
            {
                health.currentHealth -= 25;
                ennemy.SetTrigger("hit");
            }
        }
        if (isfloating)
        {
            rb.isKinematic = true;
            transform.parent = other.transform;
        }
    }
}

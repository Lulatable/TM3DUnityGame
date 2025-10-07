using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Prop : MonoBehaviour
{

    public Health healthManager;
    public Animator animator;
    public Animator animatorplayer;
    public GameObject hitscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitscreen != null)
        {
            if (hitscreen.GetComponent<Image>().color.a > 0)
            {
                var color = hitscreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                hitscreen.GetComponent<Image>().color = color;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {



        if (healthManager)
        {

           // if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
           // {

                healthManager.currentHealth -= 25;
                animatorplayer.SetTrigger("hit");
                var color = hitscreen.GetComponent<Image>().color;
                color.a = 0.8f;
                hitscreen.GetComponent<Image>().color = color;
           // }
        }
    }
}

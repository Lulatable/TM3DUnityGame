using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class caractercontrol : MonoBehaviour
{
    public float moveUnit;
    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    private UnityEngine.Quaternion direction;
    private UnityEngine.Quaternion absolutedirection;
    public float turnSmoothTime;
    // public Transform cam;
    private long attackTick;
    private float turnSmoothVelocity;

    public player player;
    public Animator animator;
    public GameObject camera_follow;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        // To smooth out the movement of the rigidbody between frames
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        // So that the character doesn't collapse
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        animator = GetComponent<Animator>();
        player = new player(this, animator);
        variableManager.instance.countDeath = false;
    }

    // Update is called once per frame
    
    
    
    void Update()
    {
        if (!variableManager.instance.isDying)
        {
            direction = getDirections();
            if (variableManager.instance.ShortAttack && (attackTick == 0 || System.DateTime.Now.Ticks - attackTick > 10000000))
            {
                animator.SetTrigger("Short Attack");

                attackTick = System.DateTime.Now.Ticks;
            }


            if (animator.GetCurrentAnimatorStateInfo(1).IsName("Short Attack"))
            {
                variableManager.instance.CanAttack = true;
            }
            else variableManager.instance.CanAttack = false;

            if (variableManager.instance.LongAttack)
            {
                animator.SetTrigger("Start Long Attack");

                
            }
            if (variableManager.instance.LongAttackThrow)
            {
                animator.SetTrigger("End Long Attack");
            }
        }
        

        // this.gameObject.transform.rotation = direction;



        //if (variableManager.instance.MoveRight == true)
        //{
        //UnityEngine.Vector3 rotationVector = new UnityEngine.Vector3(0, 90, 0);
        //UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Euler(rotationVector);
        //return UnityEngine.Quaternion.Euler(0f, 90f, 0f);
        //}
        // if (variableManager.instance.MoveRight == true || variableManager.instance.MoveUp == true || variableManager.instance.MoveLeft == true || variableManager.instance.MoveDown == true)
        //{
        //  rb.velocity = vectorM * speed;
        //}

        //   if (variableManager.instance.MoveRight || variableManager.instance.MoveDown || variableManager.instance.MoveUp || variableManager.instance.MoveLeft)
        // {
        //   rb.velocity = vectorM; //* speed;
        //}
        /* if (variableManager.instance.MoveLeft == true)
         {
             rb.velocity = vectorM * speed;
         }
         if (variableManager.instance.MoveDown == true)
         {
             rb.velocity = vectorM * speed;
         }
         if (variableManager.instance.MoveUp == true)
         {
             rb.velocity = vectorM * speed;
         }*/



    }





    public void FixedUpdate()

    {
       

         player.Update();
        if (variableManager.instance.isDying)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                variableManager.instance.countDeath = true;
            }
            else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && variableManager.instance.countDeath)
            {
                variableManager.instance.isGameOver = true;
            }

            
        }
        else
        {

            if (direction == UnityEngine.Quaternion.identity)
            {
                absolutedirection = transform.rotation;
                
            }
            if (direction != UnityEngine.Quaternion.identity)
            {
                float angle = Mathf.SmoothDampAngle(
                    transform.eulerAngles.y,
                    direction.eulerAngles.y + absolutedirection.eulerAngles.y,//+ cam.eulerAngles.y,
                    ref turnSmoothVelocity,
                    turnSmoothTime
                );
                rb.MoveRotation(UnityEngine.Quaternion.Euler(0f, angle, 0f));

                UnityEngine.Vector3 vectorM = new(0, 0, moveUnit);
                vectorM = UnityEngine.Quaternion.Euler(0, absolutedirection.eulerAngles.y + direction.eulerAngles.y, 0) * vectorM;
                // vectorM = UnityEngine.Quaternion.Euler(0, direction.eulerAngles.y, 0) * vectorM;
                rb.MovePosition(rb.position + vectorM * speed * Time.fixedDeltaTime);
            }



            //UnityEngine.Quaternion direction = getDirections();
            //this.gameObject.transform.rotation = direction;

            //UnityEngine.Vector3 vectorM = new(0, 0, moveUnit);
            //vectorM = UnityEngine.Quaternion.Euler(0, direction.eulerAngles.y, 0) * vectorM;

            //if (variableManager.instance.MoveRight || variableManager.instance.MoveDown || variableManager.instance.MoveUp || variableManager.instance.MoveLeft)
            //{
            //  rb.AddForce(vectorM * speed,ForceMode.Force);
            // rb.velocity = vectorM * speed;
            // }
        }
    }
        public UnityEngine.Quaternion getDirections()
        {
            if (variableManager.instance.MoveUp == true && variableManager.instance.MoveRight == true)
            {
                return UnityEngine.Quaternion.Euler(0f,  45f, 0f);
            }
            if (variableManager.instance.MoveUp == true && variableManager.instance.MoveLeft == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 315f, 0f);
            }
            //if (variableManager.instance.MoveDown == true && variableManager.instance.MoveRight == true)
            //{
            //    return UnityEngine.Quaternion.Euler(0f, 135f, 0f);
           // }
            //if (variableManager.instance.MoveDown == true && variableManager.instance.MoveLeft == true)
           // {
             //   return UnityEngine.Quaternion.Euler(0f, 225f, 0f);
            //}
            if (variableManager.instance.MoveRight == true)
            {
                return UnityEngine.Quaternion.Euler(0f,90f, 0f);
            }
            if (variableManager.instance.MoveLeft == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 270f, 0f);
            }
           // if (variableManager.instance.MoveDown == true)
            //{
             //   return UnityEngine.Quaternion.Euler(0f, 180f, 0f);
           // }
            if (variableManager.instance.MoveUp == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 360f, 0f);
            }

            return UnityEngine.Quaternion.identity;


        }
    public void testFunction()
    {
        Debug.Log("Function");
    }
    }


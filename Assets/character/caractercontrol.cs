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

    private Animator animator;
    // Start is called before the first frame update
    private UnityEngine.Quaternion direction;
    public float turnSmoothTime;
    // public Transform cam;

    private float turnSmoothVelocity;

    public player player;

    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // To smooth out the movement of the rigidbody between frames
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        // So that the character doesn't collapse
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        animator = GetComponent<Animator>();
        player = new player(this, animator);
    }

    // Update is called once per frame
    void Update()
    {
        player.Update();
        direction = getDirections();
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
        if (direction != UnityEngine.Quaternion.identity)
        {
            float angle = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                direction.eulerAngles.y , //+ cam.eulerAngles.y,
                ref turnSmoothVelocity,
                turnSmoothTime
            );
            rb.MoveRotation(UnityEngine.Quaternion.Euler(0f, angle, 0f));

            UnityEngine.Vector3 vectorM = new(0, 0, moveUnit);
            vectorM = UnityEngine.Quaternion.Euler(0, direction.eulerAngles.y, 0) * vectorM;
            rb.MovePosition(rb.position + vectorM * speed * Time.fixedDeltaTime); 

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
                return UnityEngine.Quaternion.Euler(0f, 45f, 0f);
            }
            if (variableManager.instance.MoveUp == true && variableManager.instance.MoveLeft == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 315f, 0f);
            }
            if (variableManager.instance.MoveDown == true && variableManager.instance.MoveRight == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 135f, 0f);
            }
            if (variableManager.instance.MoveDown == true && variableManager.instance.MoveLeft == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 225f, 0f);
            }
            if (variableManager.instance.MoveRight == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 90f, 0f);
            }
            if (variableManager.instance.MoveLeft == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 270f, 0f);
            }
            if (variableManager.instance.MoveDown == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 180f, 0f);
            }
            if (variableManager.instance.MoveUp == true)
            {
                return UnityEngine.Quaternion.Euler(0f, 360f, 0f);
            }

            return UnityEngine.Quaternion.identity;


        }
    }


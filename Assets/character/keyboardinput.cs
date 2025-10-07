using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class keyboardinput : MonoBehaviour
{
    //gère les input des touches du clavier

    private bool crouchactive;
   

    // Start is called before the first frame update
    void Start()
    {
        crouchactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // bool mup = Input.GetKey(KeyCode.W);
        //variableManager.instance.MoveUp = mup;
        // bool mdown = Input.GetKey(KeyCode.S);
        // variableManager.instance.MoveUp = mdown;
        // bool mright = Input.GetKey(KeyCode.D);
        //variableManager.instance.MoveUp = mright;
        //bool mleft = Input.GetKey(KeyCode.A);
        //variableManager.instance.MoveUp = mleft;



        // vérifie si une touche est pressé
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            variableManager.instance.isMoving = true;
        }
        else variableManager.instance.isMoving = false;
        if (Input.GetKey(KeyCode.W))
        {
            variableManager.instance.MoveUp = true;
        }
        else variableManager.instance.MoveUp = false;
        if (Input.GetKey(KeyCode.D))
        {
            variableManager.instance.MoveRight = true;
        }
        else variableManager.instance.MoveRight = false;
        if (Input.GetKey(KeyCode.S))
        {
            variableManager.instance.MoveDown = true;
        }
        else variableManager.instance.MoveDown = false;
        if (Input.GetKey(KeyCode.A))
        {
            variableManager.instance.MoveLeft = true;
        }
        else variableManager.instance.MoveLeft = false;

        if (Input.GetKeyDown(KeyCode.C)  && !crouchactive )
        {
            variableManager.instance.Crouch = true;
            crouchactive = true;
        }
        
        else if (Input.GetKeyDown(KeyCode.C) && crouchactive)
        {
            variableManager.instance.Crouch = false;
            crouchactive = false;
        }

        

        if (Input.GetKey(KeyCode.Space))
        {
            variableManager.instance.ShortAttack = true;
        }
        else variableManager.instance.ShortAttack = false;

        if (Input.GetMouseButtonDown(0))
        {
            variableManager.instance.LongAttack = true;
            

        }
        else if (variableManager.instance.LongAttack)
        {
            variableManager.instance.LongAttack = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            variableManager.instance.LongAttackThrow = true;


        }
        if (Input.GetMouseButton(1))
        {
            variableManager.instance.MoveCamera = true;
        }
        else variableManager.instance.MoveCamera = false;
    }   
}


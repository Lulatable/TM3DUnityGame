using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardinput : MonoBehaviour
{
    //gère les input des touches du clavier





    // Start is called before the first frame update
    void Start()
    {

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
    }
}


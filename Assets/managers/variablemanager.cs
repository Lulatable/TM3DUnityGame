using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


    public class variableManager : singleton<variableManager>
    {
        //gère les variable public
        public bool MoveRight;
        public bool MoveUp;
        public bool MoveDown;
        public bool MoveLeft;
        public bool Crawl;

    }

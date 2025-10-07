using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (variableManager.instance.isGameOver == true)
        {
            SceneManager.LoadSceneAsync("end");
        }
    }
}

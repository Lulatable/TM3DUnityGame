using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
      if (currentHealth == 0)
        {
            variableManager.instance.isGameOver = true;
        }
    }
}

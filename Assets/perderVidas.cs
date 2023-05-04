using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perderVidas : MonoBehaviour
{

    public GameObject[] hearts;
    private int life;
    
    void Start()
    {
        
    }

    
    private void Update()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }

    private void PlayerDamage()
    {
        life--;
    }
}

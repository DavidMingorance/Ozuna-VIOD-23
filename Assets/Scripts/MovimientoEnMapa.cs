using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnMapa : MonoBehaviour
{

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        if (moveX > 0)
        {
            sr.flipX = false;
        }
        else if (moveX < 0)
        {
            sr.flipX = true;
        }
    }
}

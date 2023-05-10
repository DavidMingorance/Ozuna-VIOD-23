using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    public Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update() //anim.SetBool("Run", true);
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jump", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }
    }
}
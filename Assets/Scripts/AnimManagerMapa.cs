using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManagerMapa : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("RunDown", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("RunDown", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("RunUp", true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("RunUp", false);
        }
    }
}
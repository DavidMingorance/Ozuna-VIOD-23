using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public GameObject player;

    public GameObject upDestination;
    public GameObject downDestination;
    public GameObject leftDestination;
    public GameObject rightDestination;

    private bool currentStage;

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
        if (transform.position == player.transform.position && (Input.GetKeyDown(KeyCode.E)))
        {
            SceneManager.LoadScene(2);
        }

        if (transform.position == player.transform.position)
        {
            currentStage = true;
        }
        else
        {
            currentStage = false;
        }

        if (currentStage)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if(upDestination != null)
                {
                    currentStage = false;
                    StartCoroutine(DoUp());
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (downDestination != null)
                {
                    currentStage = false;
                    StartCoroutine(DoDown());
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (rightDestination != null)
                {
                    currentStage = false;
                    StartCoroutine(DoRight());
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (leftDestination != null)
                {
                    currentStage = false;
                    StartCoroutine(DoLeft());
                }
            }
        }
    }

    IEnumerator DoUp()
    {
        yield return new WaitForSeconds(1 / 60);
        while(player.transform.position != upDestination.transform.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, upDestination.transform.position, 8f * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator DoDown()
    {
        yield return new WaitForSeconds(1 / 60);
        while (player.transform.position != downDestination.transform.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, downDestination.transform.position, 8f * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator DoLeft()
    {
        yield return new WaitForSeconds(1 / 60);
        while (player.transform.position != leftDestination.transform.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, leftDestination.transform.position, 8f * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator DoRight()
    {
        yield return new WaitForSeconds(1 / 60);
        while (player.transform.position != rightDestination.transform.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, rightDestination.transform.position, 8f * Time.deltaTime);
            yield return null;
        }
    }
}
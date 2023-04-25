using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rata : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rebote>().Rebotar(20, other.GetContact(0).normal);
        }
    }
}

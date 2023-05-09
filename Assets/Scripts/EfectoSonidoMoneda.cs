using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonidoMoneda : MonoBehaviour
{

    [SerializeField] private AudioClip collect1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControladorSonido.Instance.EjecutarSonido(collect1);
            Destroy(gameObject);
        }
    }
}

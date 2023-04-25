using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{

    private playerScript movimientoJugador;

    [SerializeField] private float tiempoPerdida;

    private Animator animator;
    
    void Start()
    {
        movimientoJugador = GetComponent<playerScript>();
        animator = GetComponent<Animator>();
    }

  

    public void Rebotar(int power, Vector2 posicion)
    {
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        movimientoJugador.Rebote(posicion);
    }

    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdida);
        movimientoJugador.sePuedeMover = true;
    }
}

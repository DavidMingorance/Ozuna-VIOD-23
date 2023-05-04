using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatePlayer : MonoBehaviour
{
    [SerializeField] private float vida;

    private playerScript movimientoJugador;


    public void TomarDaño(float daño)
    {
        vida -= daño;
    }
}

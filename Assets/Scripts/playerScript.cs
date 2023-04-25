using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

   

    public float velocidadMovimiento;
    private Rigidbody2D rb;
    public float fuerzaSalto = 4.5f;

    private Vector3 respawnPoint;
    public GameObject colisionIferior;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * velocidadMovimiento;
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.identity : Quaternion.Euler(-0, -180, -0);
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            colisionIferior.transform.position = new Vector2(transform.position.x, colisionIferior.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColisionInferior")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }
        
    }

    /* public void Recolocar()
     {
         transform.position = new Vector3(xInicial, yInicial, 0);
     }*/
}

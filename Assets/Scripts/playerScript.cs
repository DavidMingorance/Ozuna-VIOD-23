using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    private AudioSource Jump;

    public Sprite sprite2;

    public float targetTime = 1.2f;

    public SpriteRenderer sr;

    public GameObject[] hearts;

    [SerializeField] private float vida = 3;

    private playerScript movimientoJugador;

    [SerializeField] private float tiempoPerdida;

    private Animator animator;


    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote; 
   

    public float velocidadMovimiento;
    private Rigidbody2D rb;
    public float fuerzaSalto = 4.5f;

    private Vector3 respawnPoint;
    public GameObject colisionIferior;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        movimientoJugador = GetComponent<playerScript>();
        animator = GetComponent<Animator>();
        Jump= GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * velocidadMovimiento;
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.identity : Quaternion.Euler(-0, -180, -0);
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            colisionIferior.transform.position = new Vector2(transform.position.x, colisionIferior.transform.position.y);
            
            Jump.Play();
            
        }
        if (vida < 1)
        {
            
            Destroy(hearts[0].gameObject);
        }
        else if (vida < 2)
        {
        
            Destroy(hearts[1].gameObject);
        }
        else if (vida < 3)
        {
            
            Destroy(hearts[2].gameObject);
        }
        if (vida == 0)
        {
            StartCoroutine(dead()); 
        }
    }

    private IEnumerator dead()
    {
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(1.0f);
        anim.GetComponent<Animator>().enabled = false;
        ChangeSprite();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(5);
    }

    public void ChangeSprite()
    {
        sr.sprite = sprite2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColisionInferior")
        {
            vida--;
            transform.position = respawnPoint;
        }
        else if (collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }
        
    }

    public void Rebotar(int daño, Vector2 posicion)
    {
        vida -= daño;
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        movimientoJugador.Rebote(posicion);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

    }
    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdida);
        movimientoJugador.sePuedeMover = true;

    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }

    /* public void Recolocar()
     {
         transform.position = new Vector3(xInicial, yInicial, 0);
     }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    public Animator animator;
    public Transform jugador;
    //Persegir al personaje
    public string correr;
    public string atacar;
    public float velocidad;
    public NavMeshAgent AI;
    //Muerte del enemigo
    public float vida;
    public int DañoRecibido=10;
    //Movimiento general
    public bool TipoMovimiento=false;
    public float speed = 2f; // Velocidad de movimiento
    public float distanciaDeteccion = 5f;
    private bool sigueMoviendo = true; // Variable para controlar si el personaje sigue moviéndose
    private int pos = 0;
    private float timer = 0.11f; // Temporizador para retrasar el movimiento
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
    }

    void Update()
    {
        //Vida del enemigo
        if(vida<=0){
            animator.CrossFade("Sword And Shield Death", 0f);
            Destroy(gameObject);
        }

        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        if (distanciaAlJugador < distanciaDeteccion)
        {
            sigueMoviendo = false;
            distanciaDeteccion=1000f;
            AI.speed=velocidad;
            AI.SetDestination(jugador.position);

            if(AI.velocity==Vector3.zero){
                animator.CrossFade(atacar,0f);
            }
            else{
                animator.CrossFade(correr,0f);
            }
        }

        if (pos != 1)
        {
            timer += Time.deltaTime;
            print(timer);
            if (timer < 11f)
            {
                animator.SetBool("reposo", true);
                animator.SetBool("caminar", false);
                sigueMoviendo = true;
            }
            else
            {
                animator.CrossFade("Walking", 0f);
                animator.SetBool("girar", false);
                animator.SetBool("reposo", false);
                animator.SetBool("caminar", true);
            }
        }

        if (timer >= 11f)
        {
            if (sigueMoviendo)
            {
                float movement = speed * Time.deltaTime;
                transform.Translate(Vector3.forward * movement);
            }
            else
            {
                pos = 1;
                timer = 0;
                animator.CrossFade("Left Turn", 0f);
                animator.SetBool("girar", true);
                animator.SetBool("caminar", false);
            }
        }

        if (timer == 0)
        {
            if(TipoMovimiento){
                transform.Rotate(Vector3.up, 270f);
            }
            else{
                transform.Rotate(Vector3.up, 180f);
            }
            pos = 0;
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Pared"))
        {
            sigueMoviendo = false;
        }
        //detecta cuando es impactado por el daño del jugador
        if (collision.gameObject.CompareTag("Disparojugador"))
        {
            vida -= DañoRecibido;
        }
    }

}



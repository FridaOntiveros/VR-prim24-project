using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Movimiento : MonoBehaviour
{
    public Transform jugador;
    public Animator animator;
    public string caminar;
    public string atacar;
    public float velocidad;
    public NavMeshAgent AI;
    void Update()
    {
        AI.speed=velocidad;
        AI.SetDestination(jugador.position);

        if(AI.velocity==Vector3.zero){
            animator.CrossFade(atacar,0f);
        }
        else{
            animator.CrossFade(caminar,0f);
        }
    }
}

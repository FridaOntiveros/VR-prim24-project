using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearEnemigos : MonoBehaviour
{
    public GameObject Enemigo;
    public Transform respawn;
    public int Nenemigos = 2;
    private float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarEnemigos());
    }

    IEnumerator GenerarEnemigos()
    {
        while (Nenemigos > 0)
        {
            yield return new WaitForSeconds(3f); // Esperar 3 segundos
            Instantiate(Enemigo, respawn.position, respawn.rotation);
            Nenemigos--;
        }
    }
}


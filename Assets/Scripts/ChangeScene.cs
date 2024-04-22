using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Variable para almacenar el nombre de la escena a la que queremos cambiar
    public string nombreDeEscenaACambiar;
    public Animator transition;

    public void CambiarEscena(string nombreDeEscenaACambiar)
    {
        // Comprobamos si el nombre de la escena no está vacío
        if (!string.IsNullOrEmpty(nombreDeEscenaACambiar))
        {
            StartCoroutine(FadeScene(nombreDeEscenaACambiar));
        }
        else
        {
            Debug.LogError("El nombre de la escena está vacío. Por favor, asigna un nombre de escena válido.");
        }
    }

    IEnumerator FadeScene(string nombreDeEscenaACambiar){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        // Cambiamos a la escena especificada
        SceneManager.LoadScene(nombreDeEscenaACambiar);
    }
}

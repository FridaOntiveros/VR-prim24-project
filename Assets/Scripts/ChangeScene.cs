using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Variable para almacenar el nombre de la escena a la que queremos cambiar
    public string nombreDeEscenaACambiar;

    public void CambiarEscena(string nombreDeEscenaACambiar)
    {
        // Comprobamos si el nombre de la escena no está vacío
        if (!string.IsNullOrEmpty(nombreDeEscenaACambiar))
        {
            // Cambiamos a la escena especificada
            SceneManager.LoadScene(nombreDeEscenaACambiar);
        }
        else
        {
            Debug.LogError("El nombre de la escena está vacío. Por favor, asigna un nombre de escena válido.");
        }
    }
}

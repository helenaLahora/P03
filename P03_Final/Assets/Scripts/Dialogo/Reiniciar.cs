using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        // Obtén el índice de la escena actual
        int escenaActualIndex = SceneManager.GetActiveScene().buildIndex;

        // Carga la escena actual nuevamente
        SceneManager.LoadScene(escenaActualIndex);
    }
}






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Material wetMaterial;       // Material "mojado" para asignar al jugador
    private Material originalMaterial; // Material original del jugador
    private bool isWet = false;        // Indicador de si el jugador está mojado

    private void Start()
    {
        // Guardar el material original del jugador
        Renderer groundRenderer = GetComponent<Renderer>();
        if (groundRenderer != null)
        {
            originalMaterial = groundRenderer.material;
        }
        else
        {
            //Debug.LogError("No se encontró el componente MeshRenderer en el jugador.");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if ( !isWet)
        {
            //Debug.Log("Colisión con lluvia detectada en el jugador.");

            // Cambiar el material del jugador al material "mojado"
            ChangePlayerMaterial(wetMaterial);
            isWet = true;

            // Iniciar la corutina para desvanecer el efecto de mojado después de 5 segundos
            StartCoroutine(FadeWetEffect());
        }
    }

    private void ChangePlayerMaterial(Material newMaterial)
    {
        Renderer groundRenderer = GetComponent<Renderer>();
        if (groundRenderer != null)
        {
            groundRenderer.material = newMaterial;
        }
        else
        {
            //Debug.LogError("No se encontró el componente MeshRenderer en el jugador.");
        }
    }

    private System.Collections.IEnumerator FadeWetEffect()
    {
        // Esperar 5 segundos
        yield return new WaitForSeconds(5f);

        // Cambiar el material del jugador de vuelta al material original
        ChangePlayerMaterial(originalMaterial);
        isWet = false;
    }
}

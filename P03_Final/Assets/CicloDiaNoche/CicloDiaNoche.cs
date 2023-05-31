using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CicloDiaNoche : MonoBehaviour
{
    public float duracionDia = 60f; // Duración total de un día en segundos
    public Gradient gradienteColorLuz; // Gradiente de colores para la luz ambiental
    public Material skyboxDia; // Skybox para el día
    public Material skyboxNoche; // Skybox para la noche
    public Transform luna; // Transform de la luna
    public GameObject[] objetosEstrellas; // Array de objetos que actúan como estrellas

    private float rotacionActual; // Rotación actual del sol
    private float horaDelDia; // Hora del día normalizada (0-1)

    private Light luzSolar; // Componente Light del sol

    private void Start()
    {
        // Obtenemos la referencia a la componente Light del GameObject actual
        luzSolar = GetComponent<Light>();
        // Configuramos el skybox y los efectos atmosféricos iniciales
        EstablecerSkyboxYEfectosAtmosfericos();
        // Configuramos la iluminación inicial
        EstablecerIluminacion();
    }

    private void Update()
    {
        // Calculamos la rotación actual del sol
        rotacionActual += (360f / duracionDia) * Time.deltaTime;
        rotacionActual %= 360f; // Aseguramos que esté en el rango 0-359

        // Calculamos la hora del día normalizada
        horaDelDia = rotacionActual / 360f;

        // Rotamos la luz solar
        luzSolar.transform.rotation = Quaternion.Euler(rotacionActual, 0f, 0f);

        // Ajustamos la intensidad de la luz solar
        luzSolar.intensity = 1f - Mathf.Abs(horaDelDia - 0.5f) * 2f;

        // Configuramos el skybox y los efectos atmosféricos
        EstablecerSkyboxYEfectosAtmosfericos();

        // Configuramos las sombras dinámicas
        EstablecerSombrasDinamicas();

        // Configuramos la iluminación
        EstablecerIluminacion();

        // Mostrar u ocultar las estrellas según si es de día o de noche
        bool esDeNoche = horaDelDia >= 0.4f;
        MostrarEstrellas(esDeNoche);
    }

    private void EstablecerSkyboxYEfectosAtmosfericos()
    {
        // Seleccionamos el skybox según la hora del día
        RenderSettings.skybox = horaDelDia < 0.4f ? skyboxDia : skyboxNoche;
    }

    private void EstablecerSombrasDinamicas()
    {
        // Ajustamos la distancia y la intensidad de las sombras según la hora del día
        float distanciaSombras = Mathf.Lerp(100f, 10f, horaDelDia);
        QualitySettings.shadowDistance = distanciaSombras;

        luzSolar.shadowStrength = Mathf.Lerp(1f, 0.3f, horaDelDia);
    }

    private void EstablecerIluminacion()
    {
        // Calculamos la hora del día normalizada con un ciclo completo
        float horaDelDiaCicloCompleto = horaDelDia * 2f; // Duplicamos la hora del día
        if (horaDelDiaCicloCompleto > 1f)
            horaDelDiaCicloCompleto = 2f - horaDelDiaCicloCompleto; // Invertimos la hora del día duplicada

        // Configuramos el color de la luz ambiente y la luz solar utilizando el gradiente de colores
        Color colorAmbiente = gradienteColorLuz.Evaluate(horaDelDiaCicloCompleto);
        RenderSettings.ambientLight = colorAmbiente;
        luzSolar.color = colorAmbiente;
    }

    private void MostrarEstrellas(bool mostrar)
    {
        foreach (GameObject estrella in objetosEstrellas)
        {
            estrella.SetActive(mostrar);
        }
    }
}

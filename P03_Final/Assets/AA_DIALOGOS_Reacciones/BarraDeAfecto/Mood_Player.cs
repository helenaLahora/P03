using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mood_Player : MonoBehaviour
{
    public Slider _slider;
    public float FelicidadMaxima = 1f;
    public Image fillImage;

    public void Start()
    {
        _slider.value = 0.5f;
    }

    public void Update()
    {
        _slider.value = Mathf.Clamp(_slider.value, 0, FelicidadMaxima);

        if (_slider.value > 0.5f && _slider.value <= 1f)
        {
            fillImage.color = Color.green;
        }

        if (_slider.value > 0.3f && _slider.value <= 0.5f)
        {
            fillImage.color = Color.yellow;
        }

        if (_slider.value <= 0.3f)
        {
            fillImage.color = Color.red;
        }
    }
}

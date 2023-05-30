using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodBar_Slider : MonoBehaviour
{
    public Image _green;
    public Mood_Player _mood;

    void Start()
    {

    }
    
    void Update()
    {
        float AnimoNormalizado = _mood._slider.value / _mood.FelicidadMaxima;
        _green.fillAmount = AnimoNormalizado;

    }
}


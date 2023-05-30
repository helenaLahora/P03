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
        fillImage.fillAmount = 0.5f;
    }

    public void Update()
    {
        fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount, 0, FelicidadMaxima);

        if (fillImage.fillAmount > 0.5f && fillImage.fillAmount <= 1f)
        {
            fillImage.color = Color.green;
        }

        if (fillImage.fillAmount > 0.3f && fillImage.fillAmount <= 0.5f)
        {
            fillImage.color = Color.yellow;
        }

        if (fillImage.fillAmount <= 0.3f)
        {
            fillImage.color = Color.red;
        }
    }
}

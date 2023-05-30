using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightOrWrong : MonoBehaviour
{
    
    public float _AfectionPoints = 0.1f;
    public GameObject other;

    private void Start()
    {
    }

    public void Sumar()
    {
        other.GetComponent<Mood_Player>()._slider.value += _AfectionPoints;
        Debug.Log("Has ganado +10 puntos de afecto!");
    }

    public void Restart()
    {
        other.GetComponent<Mood_Player>()._slider.value -= _AfectionPoints;
        Debug.Log("Has perdido -10 puntos de afecto!");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightOrWrong : MonoBehaviour
{
    public Animator _animatorNieve;
    public Animator _animatorSelva;
    public float _AfectionPoints = 0.1f;
    public GameObject other;

    // Start is called before the first frame update
    private void Start()
    {
        _animatorNieve = gameObject.GetComponent<Animator>();
        _animatorSelva = gameObject.GetComponent<Animator>();

        if (_animatorNieve.GetCurrentAnimatorStateInfo(0).IsName("Happy") || _animatorSelva.GetCurrentAnimatorStateInfo(0).IsName("Happy_Selva"))//
        {
            other.GetComponent<Mood_Player>().fillImage.fillAmount += _AfectionPoints;
            Debug.Log("Suma +10");
        }
        else if (_animatorNieve.GetCurrentAnimatorStateInfo(0).IsName("Sad") || _animatorSelva.GetCurrentAnimatorStateInfo(0).IsName("Sad_Selva"))//
        {
            other.GetComponent<Mood_Player>().fillImage.fillAmount -= _AfectionPoints;
            Debug.Log("Resta -10");
        }
        else
        {
            Debug.Log("NO FUNCIONAAAAAAAAAAAAAAA");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowDownIntensity : MonoBehaviour
{
    [SerializeField] private ParticleIntensity script;
    [SerializeField] private float emissionRate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bonk"))
        {
            script.Intensity(emissionRate);
        }
    }
}

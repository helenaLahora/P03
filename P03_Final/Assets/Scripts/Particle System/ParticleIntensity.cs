using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleIntensity : MonoBehaviour
{
    [SerializeField] private new ParticleSystem[] particleSystem;

    public void OnOff(float rate)
    {
        foreach (ParticleSystem particle in particleSystem)
        {
            ParticleSystem.EmissionModule emission;
            emission = particle.emission;
            emission.rateOverTime = rate;
        }
    }

    public void Intensity(float intens)
    {
         
        foreach (ParticleSystem particle in particleSystem)
        {
            ParticleSystem.EmissionModule emission;
            emission = particle.emission;
            float emissionRate = emission.rateOverTime.constantMax;           
            emission.rateOverTime =  emissionRate + intens;
        }
        
    }

}

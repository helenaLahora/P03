using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleRain : MonoBehaviour
{

    ParticleSystem _particleSystem;

    bool _isPlaying;

    public Color StartColor;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleParticles();
        }

        ChangeColor();
        ChangeEmission();
       // ChangeNoise(); 
    }

    //quant més temps passa, més noise hi ha
    //void ChangeNoise()
    //{
    //    var noiseModule = _particleSystem.noise;
    //    noiseModule.strength = Time.time / 10;
    //}

    void ChangeEmission()
    {
        var emision = _particleSystem.emission;
        emision.rateOverTime = Time.time * 10;
        //_particleSystem.emission.rate = 100; //no acaba de funcionar per tant he de guardar l'emissió com a un mòdul a part, o sigui com una variable a part

    }

    void ToggleParticles()
    {
        if (_isPlaying)
            StopParticles();
        else
            StartParticles();
    }
    
    private void StopParticles()
    {
        _particleSystem.Stop();
        _isPlaying = false;
    }

    private void StartParticles()
    {
        _particleSystem.Play();
        _isPlaying = true;
        //_particleSystem.startColor = new Color(
        //    Mathf.Sin(Time.time) / 2 + 0.5f,
        //    Mathf.Cos(Time.time) / 2 + 0.5f,
        //    Mathf.sin(2 * Time.time) / 2 + 0.5f);//li fico un clor que va variant en funció del temps
        //Si vull que el color vagi canviant sempre hauriem de fer un void ChangeColor
    }

    void ChangeColor()
    {
        
        _particleSystem.startColor = new Color(
            Mathf.Sin(Time.time) / 2 + 0.5f,
            Mathf.Cos(Time.time) / 2 + 0.5f,
            Mathf.Sin(2 * Time.time) / 2 + 0.5f);//li fico un clor que va variant en funció del temps
    }
}

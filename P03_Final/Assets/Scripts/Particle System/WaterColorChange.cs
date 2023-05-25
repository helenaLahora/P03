using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColorChange : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem fireParticles;
    public Color closeColor;
    public Color farColor;

    private void Update()
    {
        // Calculate the distance between the player and the fire object
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Compare the distance with a threshold value
        if (distance < 9f)
        {
            // Change the color of the particle system to closeColor
            var mainModule = fireParticles.main;
            mainModule.startColor = closeColor;
        }
        else
        {
            // Change the color of the particle system to farColor
            var mainModule = fireParticles.main;
            mainModule.startColor = farColor;
        }
    }
}

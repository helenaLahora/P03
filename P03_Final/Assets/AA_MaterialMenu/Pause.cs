using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public string playerTag = "bonk";

    private bool isPlayerPaused = false;

    private void Update()
    {
        if (isPlayerPaused)
        {
            // Pausar el objeto con la etiqueta "Player"
            GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
            foreach (GameObject player in players)
            {
                var animator = player.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.enabled = false;
                }
            }
        }
        else
        {
            // Reanudar el objeto con la etiqueta "Player"
            GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
            foreach (GameObject player in players)
            {
                var animator = player.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.enabled = true;
                }
            }
        }
    }

    public void TogglePlayerPause()
    {
        isPlayerPaused = !isPlayerPaused;
    }
}



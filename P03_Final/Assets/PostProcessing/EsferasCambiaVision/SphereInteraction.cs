using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereInteraction : MonoBehaviour
{
    public PostProcessingController postProcessingController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bonk"))
        {
            postProcessingController.SetIsTouchingSphere(true);
            Debug.Log("bonk entered the sphere trigger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bonk"))
        {
            postProcessingController.SetIsTouchingSphere(false);
            Debug.Log("bonk exited the sphere trigger.");
        }
    }
}

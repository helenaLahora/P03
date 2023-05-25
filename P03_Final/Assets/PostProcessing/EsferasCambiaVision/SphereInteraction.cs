using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereInteraction : MonoBehaviour
{
    public PostProcessingController postProcessingController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            postProcessingController.SetIsTouchingSphere(true);
            Debug.Log("Player entered the sphere trigger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            postProcessingController.SetIsTouchingSphere(false);
            Debug.Log("Player exited the sphere trigger.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[System.Serializable]
public class PostProcessPrefab
{
    public GameObject prefab;
    public bool isActive = true;
}

public class PostProcessingController : MonoBehaviour
{
    public List<PostProcessPrefab> postProcessPrefabs;
    private List<GameObject> postProcessObjects;
    private bool isTouchingSphere;

    private void Awake()
    {
        InstantiatePostProcessObjects();
    }

    private void Update()
    {
        if (isTouchingSphere)
        {
            EnablePostProcessing();
        }
        else
        {
            DisablePostProcessing();
        }
    }

    private void EnablePostProcessing()
    {
        foreach (var obj in postProcessObjects)
        {
            obj.SetActive(true);
        }

        Debug.Log("Post-processing enabled.");
    }

    private void DisablePostProcessing()
    {
        foreach (var obj in postProcessObjects)
        {
            obj.SetActive(false);
        }

        Debug.Log("Post-processing disabled.");
    }

    private void InstantiatePostProcessObjects()
    {
        postProcessObjects = new List<GameObject>();

        foreach (var prefabData in postProcessPrefabs)
        {
            if (prefabData.isActive)
            {
                GameObject postProcessObject = Instantiate(prefabData.prefab, transform.position, Quaternion.identity, transform);
                postProcessObject.SetActive(false);
                postProcessObjects.Add(postProcessObject);
            }
        }
    }

    public void SetIsTouchingSphere(bool touching)
    {
        isTouchingSphere = touching;
        Debug.Log("IsTouchingSphere set to: " + touching);
    }
}
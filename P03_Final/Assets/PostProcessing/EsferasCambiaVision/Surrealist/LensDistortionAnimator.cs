using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LensDistortionAnimator : MonoBehaviour
{
    public float animationSpeed = 1f;
    public float minValue = -0.5f;
    public float maxValue = 0.5f;
    public float smoothTime = 0.3f;

    private Volume boxVolume;
    private LensDistortion lensDistortion;
    private float currentValue;
    private float targetValue;
    private float velocity;

    private void Start()
    {
        boxVolume = GetComponentInParent<Volume>();
        if (boxVolume == null)
        {
            Debug.LogError("Box Volume component not found in the parent GameObject!");
            enabled = false;
            return;
        }

        if (!boxVolume.profile.TryGet(out lensDistortion))
        {
            Debug.LogError("Lens Distortion component not found in the box volume profile!");
            enabled = false;
            return;
        }

        // Set the initial value of the X multiplier
        currentValue = lensDistortion.intensity.value;

        // Generate a random target value within the specified range
        targetValue = Random.Range(minValue, maxValue);
    }

    private void Update()
    {
        // Smoothly damp the current value towards the target value based on the animation speed
        currentValue = Mathf.SmoothDamp(currentValue, targetValue, ref velocity, smoothTime, animationSpeed);

        // Update the X multiplier of the lens distortion
        lensDistortion.intensity.value = currentValue;

        // If the current value is very close to the target value, generate a new random target value
        if (Mathf.Abs(currentValue - targetValue) < 0.01f)
        {
            targetValue = Random.Range(minValue, maxValue);
        }
    }
}
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;

public class HueShiftAnimation : MonoBehaviour
{
    public float speed = 1f;
    public float amplitude = 140f;
    public float minValue = 40f;
    public float maxValue = 180f;

    private ColorAdjustments colorAdjustments;
    private float initialHueShift;
    private float currentTime = 0f;

    private void Start()
    {
        Volume volume = GetComponent<Volume>();
        if (!volume.profile.TryGet(out colorAdjustments))
        {
            Debug.LogError("Color Adjustments not found in the assigned Volume Profile!");
            enabled = false;
            return;
        }

        // Store the initial hue shift value for reference
        initialHueShift = colorAdjustments.hueShift.value;
    }

    private void Update()
    {
        currentTime += Time.deltaTime * speed;
        float hueShift = Mathf.PingPong(currentTime * amplitude, maxValue - minValue) + minValue;
        colorAdjustments.hueShift.Override(initialHueShift + hueShift);
    }
}
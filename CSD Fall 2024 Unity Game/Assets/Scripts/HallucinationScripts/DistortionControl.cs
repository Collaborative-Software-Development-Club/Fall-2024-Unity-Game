using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionControl : MonoBehaviour
{
    private Material objectMaterial;
    private Vector2 distortionSpeed;
    private float distortionScale;
    private Vector2 distortionStrength;
    public Vector2 distortionSpeedGradient = new Vector2(10.0f, 10.0f);
    public Vector2 distortionStrengthGradient = new Vector2(10.0f, 10.0f);
    public float distortionScaleGradient = 10f;
    public int sporeStep = 5; // The number of spores required to enhance the distortion effect
    private int currentSporeCount;
    private int previousSpore;
    private Hallucination hallucinationComponent; // Cache the Hallucination component
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().sharedMaterial; // Use sharedMaterial to avoid creating material instances
        distortionSpeed = objectMaterial.GetVector("_DistortionSpeed");
        distortionScale = objectMaterial.GetFloat("_GradientScale");
        distortionStrength = objectMaterial.GetVector("_DistortionStrength");
        hallucinationComponent = GameObject.Find("Fox").GetComponent<Hallucination>(); // Cache the Hallucination component
        Debug.Log(hallucinationComponent);
        currentSporeCount = hallucinationComponent.sporeCount;
        random = new System.Random();
        previousSpore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentSporeCount = hallucinationComponent.sporeCount; // Use cached component for spore count
        if (currentSporeCount != previousSpore)
        {
            updateDistortion();
        }
        // Update previous spore count
        previousSpore = currentSporeCount;
    }

    void updateDistortion()
    {
        // If sporeCount changes and reaches a multiple of sporeStep
        if (currentSporeCount % sporeStep == 0 && currentSporeCount != previousSpore)
        {
            // Update material properties
            objectMaterial.SetVector("_DistortionSpeed", distortionSpeed + distortionSpeedGradient);
            objectMaterial.SetFloat("_GradientScale", distortionScale + distortionScaleGradient);
            objectMaterial.SetVector("_DistortionStrength", distortionStrength + distortionStrengthGradient);

            // Update internal state
            distortionSpeed += distortionSpeedGradient;
            distortionStrength += distortionStrengthGradient;
            distortionScale += distortionScaleGradient;
        }
    }

    public void clearDistortion()
    {
        objectMaterial.SetVector("_DistortionSpeed", new Vector2(0f, 0f));
        objectMaterial.SetFloat("_GradientScale", 0);
        objectMaterial.SetVector("_DistortionStrength", new Vector2(0.1f, 0.1f));
    }
}

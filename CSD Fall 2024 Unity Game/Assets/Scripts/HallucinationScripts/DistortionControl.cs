using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionControl : MonoBehaviour
{
    private Material objectMaterial;
    private Vector2 distortionSpeed;
    private float distortionScale;
    private Vector2 distortionStrength;
    [SerializeField] private Vector2 distortionSpeedGradient;
    [SerializeField] private Vector2 distortionStrengthGradient;
    [SerializeField] private float distortionScaleGradient = 10f;
    [SerializeField] private int sporeStep = 5; // The number of spores required to enhance the distortion effect
    private int currentSporeCount;
    private int previousSpore;
    private Hallucination hallucinationComponent; // Cache the Hallucination component
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().sharedMaterial; // Use sharedMaterial to avoid creating material instances
        clearDistortion(); //Reset shader to 0
        distortionSpeed = objectMaterial.GetVector("_DistortionSpeed");
        distortionScale = objectMaterial.GetFloat("_GradientScale");
        distortionStrength = objectMaterial.GetVector("_DistortionStrength");
        hallucinationComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Hallucination>(); // Cache the Hallucination component
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentSporeCount = hallucinationComponent.sporeCount;
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


        //Move hallcination effect to follow player
        transform.position = playerTransform.position;

    }

    void updateDistortion()
    {
        // If sporeCount changes and reaches a multiple of sporeStep
        if (currentSporeCount % sporeStep == 0 && currentSporeCount != previousSpore)
        {
            // Update material properties
            objectMaterial.SetVector("_DistortionSpeed", distortionSpeedGradient);
            objectMaterial.SetFloat("_GradientScale", distortionScale + distortionScaleGradient);
            objectMaterial.SetVector("_DistortionStrength", distortionStrengthGradient);

            // Update internal state
            distortionSpeed = distortionSpeedGradient;
            distortionStrength = distortionStrengthGradient;
            distortionScale += distortionScaleGradient;
        }
    }

    public void clearDistortion()
    {
        objectMaterial.SetVector("_DistortionSpeed", Vector2.zero);
        objectMaterial.SetFloat("_GradientScale", 0);
        objectMaterial.SetVector("_DistortionStrength", Vector2.zero);
    }
}

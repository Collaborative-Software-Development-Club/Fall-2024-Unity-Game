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
    public int sporeStep = 5; // The number of spore required to enhance the distortion effect
    private bool distortionIncreased = false;
    private int previousSpore;
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
        distortionSpeed = objectMaterial.GetVector("_DistortionSpeed");
        distortionScale = objectMaterial.GetFloat("_GradientScale");
        distortionStrength = objectMaterial.GetVector("_DistortionStrength");
        previousSpore = GameObject.Find("Fox").GetComponent<Hallucination>().sporeCount;
        random = new System.Random(); 
    }

    // Update is called once per frame
    void Update()
    {
        distortionStrength = objectMaterial.GetVector("_DistortionStrength");
        updateDistortion();
    }

    void updateDistortion()
    {
        int currentSporeCount = GameObject.Find("Fox").GetComponent<Hallucination>().sporeCount;

        // if sporeCount changes and it's variation reaches sporeStep
        if (currentSporeCount % sporeStep == 0 && currentSporeCount != previousSpore)
        {
            if (!distortionIncreased) 
            {
                // update parameters of material
                objectMaterial.SetVector("_DistortionSpeed", distortionSpeed + distortionSpeedGradient);
                objectMaterial.SetFloat("_GradientScale", distortionScale + distortionScaleGradient);

                objectMaterial.SetVector("_DistortionStrength", distortionStrength+distortionStrengthGradient);

                // update variants
                distortionSpeed += distortionSpeedGradient;
                distortionStrength += distortionStrengthGradient;
                distortionScale += distortionScaleGradient;

                // update flag
                distortionIncreased = true;
            }
        }
        else if (currentSporeCount % sporeStep != 0) // reset flag
        {
            distortionIncreased = false;
        }

        // ¼ÇÂ¼µ±Ç° sporeCount
        previousSpore = currentSporeCount;
    }

    void clearDistortion()
    {

      objectMaterial.SetVector("_DistortionSpeed", new Vector2(0f, 0f));
      objectMaterial.SetFloat("_GradientScale", 0);
      objectMaterial.SetVector("_DistortionStrength", new Vector2(0f, 0f));
    }

}

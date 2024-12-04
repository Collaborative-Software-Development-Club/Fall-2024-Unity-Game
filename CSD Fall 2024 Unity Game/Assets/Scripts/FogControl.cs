using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogSpeedControl : MonoBehaviour
{
    private Material objMaterial;
    private Vector2 fogSpeed;
    private System.Random randomVector;
    private Color materialColor;


    // Start is called before the first frame update
    void Start()
    {
        objMaterial = GetComponent<Renderer>().sharedMaterial;
        fogSpeed = objMaterial.GetVector("_FogSpeed");
        randomVector = new System.Random();
        materialColor = objMaterial.GetColor("_FogColor");
    }

        // Update is called once per frame
        void Update()
        {

        }
}

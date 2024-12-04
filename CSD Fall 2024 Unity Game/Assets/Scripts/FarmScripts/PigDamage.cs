using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigDamage : MonoBehaviour
{

    public int health;
    int ghostFoxLayer;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        ghostFoxLayer = LayerMask.NameToLayer ("ghostFox");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy (gameObject);
        }
    }
    private void OnTriggerEnter2D (Collider2D collision) {
        int layerMask = collision.gameObject.layer;
        if (layerMask == ghostFoxLayer) {
            health -= 2;
        }
    }
}

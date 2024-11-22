using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLightSource : MonoBehaviour
{

    public Collider2D lightCollide;
    public Transform lightRotation;
    [SerializeField] private ShiningRock rockParent;


    // Update is called once per frame
    void Update()
    {
        updateOrientation();
    }

    public void updateOrientation()
    {
        if (rockParent.orientation == 0)
        {
            lightRotation.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rockParent.orientation == 1)
        {
            lightRotation.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (rockParent.orientation == 2)
        {
            lightRotation.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (rockParent.orientation == 3)
        {
            lightRotation.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

}

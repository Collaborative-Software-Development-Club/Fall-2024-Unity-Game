using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    [SerializeField] private List<ShiningRock> shiningRocks = new List<ShiningRock>();
    [SerializeField] private List<Collider2D> genericLightSources = new List<Collider2D>();

    void Update()
    {
        UpdateRockStates();
    }

    private void UpdateRockStates()
    {
        // Step 1: Reset the light state of all rocks.
        foreach (ShiningRock rock in shiningRocks)
        {
            rock.hasLight = false; // Assume no light initially.
        }

        // Step 2: Check lighting conditions from generic light sources.
        foreach (ShiningRock rock in shiningRocks)
        {
            Collider2D rockCollider = rock.collider;
            if (rockCollider == null) continue;

            foreach (Collider2D lightSource in genericLightSources)
            {
                if (lightSource.bounds.Intersects(rockCollider.bounds))
                {
                    rock.hasLight = true;
                    Debug.Log("GLTrue");
                    break; // Once lit, no need to check other lights.
                }
            }
        }

        // Step 3: Check lighting conditions from other rocks.
        foreach (ShiningRock rock in shiningRocks)
        {
            if (rock.hasLight) // If already lit, it can propagate light.
            {
                RockLightSource rockLight = rock.GetComponentInChildren<RockLightSource>();
                if (rockLight == null) continue;

                Collider2D lightCollider = rockLight.lightCollide;
                if (lightCollider == null) continue;

                // Check for overlaps with other rocks.
                foreach (ShiningRock otherRock in shiningRocks)
                {
                    if (otherRock == rock) continue;

                    Collider2D otherCollider = otherRock.collider;
                    if (otherCollider == null) continue;

                    if (lightCollider.bounds.Intersects(otherCollider.bounds))
                    {
                        otherRock.hasLight = true;
                        Debug.Log("GLTrue2");
                    }
                }
            }
        }

        // Step 4: Update the light status for all rocks.
        foreach (ShiningRock rock in shiningRocks)
        {
            rock.UpdateIsLit();
        }
    }
}
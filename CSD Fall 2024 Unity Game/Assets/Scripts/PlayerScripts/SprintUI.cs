using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class SprintUI : MonoBehaviour
{
    [SerializeField]
    Image sprintBar;
    public void updateSprintBar(float fillAmount)
    {
        sprintBar.fillAmount = fillAmount;
    }

    public void setVisibility(bool isVisible)
    {
        gameObject.GetComponent<Canvas>().enabled = isVisible;
    }

    public bool getVisibility()
    {
        return gameObject.GetComponent<Canvas>().enabled;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

/*
 * A little tidbit of code meant to deselect a button after it has been pressed
 * 
 * author: Ethan Vincent
 */

public class ButtonHandler : MonoBehaviour
{
    public static void ButtonNoSelect()
    {
        // Immediately deselect the button
        EventSystem.current.SetSelectedGameObject(null);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Manages items within pause menu (as well as paused/resume events)
 *  
 * Author: Ethan Vincent
 * 
 * Reference:
 * https://www.youtube.com/watch?v=qboX1FBxIHE
 */
public class PauseMenuScript : MonoBehaviour
{
    //Tracks paused state
    private bool _isPaused;

    //Events are used when we want to 
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    // Update is called once per frame
    private void Update()
    {   
        //pause menu can only be opened with escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //change current pause state to opposite pause state
            _isPaused = !_isPaused;
            

            //if it was paused, timescale becomes zero and paused event is invoked
            if (_isPaused)
            {
                PauseGame();
            } 
            //otherwise, game is resumed
            else
            {
                ResumeGame();
            }
        }
    }


    /*
     * pause & resume methods are created so game can be resumed through other means 
     * (i.e. pressing "resume" in pause menu)
     */
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        _isPaused = false;
        Time.timeScale = 1;
        GameResumed.Invoke();
        
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _isPaused = true;
        Time.timeScale = 0;
        GamePaused.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }

}

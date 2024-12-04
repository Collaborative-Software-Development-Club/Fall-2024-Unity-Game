using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUIScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    private Rigidbody2D playerRb;
    public fox foxScript;
    public GameObject[] locks = new GameObject[3];
    private int clickCounter = 0;
    public int clicksToBreak;
    private int lockIndex = 0;
    public int numLocks;

    private void Update()
    {
        if (clickCounter == clicksToBreak)
        {
            deactivateLock();
            clickCounter = 0;
            lockIndex++;
            if (lockIndex < numLocks)
            {
                activateLock();
            }
            else
            {
                deactivateCanvas();
            }
        }
    }

    public void lockScene()
    {
        activateCanvas();
        activateLock();
    } 

    public void activateCanvas()
    {
        canvas.SetActive(true);
        lockIndex = 0;
        foxScript = player.GetComponent<fox>();
        foxScript.OnDisable();
    }

    public void activateLock()
    {
        locks[lockIndex].SetActive(true);
    }

    public void deactivateCanvas()
    {
        canvas.SetActive(false);
        foxScript.OnEnable();
    }

    public void deactivateLock()
    {
        locks[lockIndex].SetActive(false);
    }

    public void BreakLock()
    {
        clickCounter++;
    }
}

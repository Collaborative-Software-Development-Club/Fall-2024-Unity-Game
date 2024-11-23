using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public GameObject raven;
    public GameObject hamster;

    private Raven ravenScript;
    private hamster hamsterScript;

    // Start is called before the first frame update
    void Start()
    {
        ravenScript = raven.GetComponent<Raven>();
        hamsterScript = hamster.GetComponent<hamster>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the state from the Raven and Hamster scripts each frame
        bool isAsideRaven = ravenScript.isAside;
        bool isAsideHamster = hamsterScript.isAside;

        // Check if the user is pressing E and the respective condition is true
        if (isAsideRaven&&Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MazeEasy");
        }

        if (isAsideHamster && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Farm");
        }
    }
}

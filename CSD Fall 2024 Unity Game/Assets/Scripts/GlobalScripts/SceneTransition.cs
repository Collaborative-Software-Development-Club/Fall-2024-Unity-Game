using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Required storyIndex for scene transition to function. Set to -1 for it to function regardless of index")]
    private int reqStoryIndex = -1;

    [SerializeField]
    [Tooltip("Name of scene to transition to")]
    private string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (reqStoryIndex==-1 || reqStoryIndex == StoryProgressionManager.getStoryIndex()))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

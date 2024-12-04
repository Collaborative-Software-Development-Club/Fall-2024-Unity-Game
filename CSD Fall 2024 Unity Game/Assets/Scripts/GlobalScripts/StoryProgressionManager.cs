using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryProgressionManager : MonoBehaviour
{
    private static int storyIndex;
    /*
     * StoryIndex tracks the progression the story has made so far
     * 0 = Started game
     * 1 = Talked to wolfTree
     * 2 = Completed Maze
     * 3 = Talked to Raven in Main
     * 4 = Finished Farm
     * 5 = Talked to Hamster in Main
     * 6 = Completed Cave
     */

    private static StoryProgressionManager Instance;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            storyIndex = 0;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            storyIndex++;
            Debug.Log(storyIndex);
        }
    }
    public static void setStoryIndex(int index)
    {
        storyIndex = index;
    }

    public static int getStoryIndex()
    {
        return storyIndex;
    }
}

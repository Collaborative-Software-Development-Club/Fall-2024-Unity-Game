using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryProgressor : MonoBehaviour
{
    [SerializeField]
    private int minStoryIndexForExistence;

    [SerializeField]
    private int reqStoryIndex;

    [SerializeField]
    private int desiredStoryIndex;


    private void Start()
    {
        if(StoryProgressionManager.getStoryIndex() >= minStoryIndexForExistence)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void advanceStory()
    {
        if (reqStoryIndex == StoryProgressionManager.getStoryIndex())
        {
            StoryProgressionManager.setStoryIndex(desiredStoryIndex);
        }
    }

    public void setMinStoryIndex(int index)
    {
        minStoryIndexForExistence = index;
    }

    public void setReqStoryIndex(int index)
    {
        reqStoryIndex = index;
    }

    public void setDesiredStoryIndex(int index)
    {
        desiredStoryIndex = index;
    }
}

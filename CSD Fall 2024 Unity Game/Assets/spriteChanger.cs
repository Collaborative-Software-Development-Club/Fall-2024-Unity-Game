using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteChanger : MonoBehaviour
{
    public List<Sprite> sprites;
    public float firstDelay;
    public float timeStep;
    private SpriteRenderer spriteRenderer;
    private int i;
    private overallTriggerControl triggerersControl;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=sprites[0];
        triggerersControl=GameObject.Find("Fox").GetComponent<overallTriggerControl>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void changeSprite()
    {
        if (i == 6)
        {
            i = 0;
        }
        i++;
        spriteRenderer.sprite=sprites[i];
    }
    private void OnBecameInvisible()
    {
        if (triggerersControl.allTriggered)
        {
            changeSprite();
        }
    }
}

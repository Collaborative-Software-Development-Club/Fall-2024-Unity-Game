using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pigTransition : MonoBehaviour
{
    public GameObject radio;
    public GameObject LoopEdges;
    public GameObject door;
    public GameObject fox;
    public GameObject ghostFox;
    public float transitSpeed;
    private Vector2 doorScale = new Vector2(81.4f, 55.38f);
    private bool startTransition = false;

    // Start is called before the first frame update
    void Start()
    {
        startTransition = radio.GetComponent<radioScript>().gotoBoss();
    }

    // Update is called once per frame
    void Update()
    {
        startTransition = radio.GetComponent<radioScript>().gotoBoss();
        if (startTransition)
        {
            transition();
        }
    }

    void transition()
    {
        Destroy(door.GetComponent<doorHitCount>());
        Destroy(door.GetComponent<Rigidbody2D>());
        door.GetComponent<Collider2D>().isTrigger = true;
        fox.GetComponent<SpriteRenderer>().sortingOrder = 7;
        ghostFox.GetComponent<SpriteRenderer>().sortingOrder= 7;
        LoopEdges.SetActive(false);
        door.transform.localScale = Vector2.Lerp(door.transform.localScale, doorScale, Time.deltaTime * transitSpeed);
    }
}

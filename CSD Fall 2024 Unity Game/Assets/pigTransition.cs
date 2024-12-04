using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class pigTransition : MonoBehaviour
{
    public GameObject radio;
    public GameObject LoopEdges;
    public GameObject door;
    public GameObject fox;
    public GameObject ghostFox;
    public float transitSpeed;
    public Tilemap nonDestructables;
    private Vector2 doorScale = new Vector2(81.4f, 55.38f);
    private bool startTransition = false;
    private bool transitioned = false;


    // Start is called before the first frame update
    void Start()
    {
        startTransition = radio.GetComponent<radioScript>().gotoBoss();
    }

    // Update is called once per frame
    void Update()
    {
        startTransition = radio.GetComponent<radioScript>().gotoBoss();
        if (startTransition && !transitioned)
        {
            preTeleport();
            Invoke ("teleport", 5);
            transitioned = true;
        } if (startTransition) {
            door.transform.localScale = Vector2.Lerp (door.transform.localScale, doorScale, Time.deltaTime * transitSpeed);
        }
    }

    void preTeleport()
    {
        Destroy(door.GetComponent<doorHitCount>());
        Destroy(door.GetComponent<Rigidbody2D>());
        door.GetComponent<Collider2D>().isTrigger = true;
        fox.GetComponent<SpriteRenderer>().sortingOrder = 7;
        ghostFox.GetComponent<SpriteRenderer>().sortingOrder= 7;
        LoopEdges.SetActive(false);
        nonDestructables.GetComponent<TilemapRenderer> ().sortingOrder = 7;
    }
    void teleport () {
        door.transform.localPosition = new Vector2 (-214, -108);
        fox.transform.localPosition = new Vector2 (-206, -108);
        ghostFox.transform.localPosition = new Vector2 (-222, -108);
    }
    void expandDoor() {
        door.transform.localScale = Vector2.Lerp (door.transform.localScale, doorScale, Time.deltaTime * transitSpeed);
    }
}

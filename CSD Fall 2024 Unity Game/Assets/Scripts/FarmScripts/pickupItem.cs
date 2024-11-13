using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    private Inventory inv;
    public GameObject player;
    public GameObject carrot;
    public GameObject tomato;
    public GameObject potato;
    public GameObject corn;
    public GameObject granade;
    public GameObject pepper;
    public GameObject redPepper;
    public GameObject greenPepper;
    private Collision Collision;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<InventoryManager>();
        Collision=player.GetComponent<Collision>();
}

    // Update is called once per frame
    void Update()
    {
        //pickup();
    }
    void pickup()
    {
        
        if (Collision.gameObject.tag == "carrot")
        {
            inv.GetComponent<Inventory>().AddItem(carrot);
        }
        else if (Collision.gameObject.tag == "tomato")
        {
            inv.AddItem(tomato);
        }
        else if(Collision.gameObject.tag == "potato")
        {
            inv.AddItem(potato);
        }
    }
}

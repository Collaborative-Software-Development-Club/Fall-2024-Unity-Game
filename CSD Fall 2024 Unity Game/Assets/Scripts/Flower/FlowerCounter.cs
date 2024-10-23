using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerCounter : MonoBehaviour
{
    private int flowerCount;
    private Text flowerText;
   
    // Start is called before the first frame update
    void Start()
    {
        //Initializes and syncs the flowerCounter text and count
        flowerText = GetComponent<Text>();
        flowerCount = 0;
        flowerText.text = flowerCount.ToString();
    }

    
    //Increments the flowerCount by one then syncs it with the text
    public void incrementFlower()
    {
        flowerCount++;
        flowerText.text = flowerCount.ToString();

    }
}

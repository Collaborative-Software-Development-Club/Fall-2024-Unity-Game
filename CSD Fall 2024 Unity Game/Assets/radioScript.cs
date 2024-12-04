using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioScript : MonoBehaviour
{
    public GameObject fPrompt;

    [SerializeField]
    private bool gotoBossFight = false;
    private bool isInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                gotoBossFight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isInRange = true;
        fPrompt.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isInRange = false;
        fPrompt.SetActive(false);
    }

    public bool gotoBoss()
    {
        return gotoBossFight;
    }
}

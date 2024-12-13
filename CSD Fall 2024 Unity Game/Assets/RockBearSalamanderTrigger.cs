using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBearSalamanderTrigger : MonoBehaviour
{
    public ShiningRock rock = new ShiningRock();
    public GameObject darkness = new GameObject();
    public GameObject bearCutscene = new GameObject();
    public GameObject barrier = new GameObject();


    // Start is called before the first frame update
    void Start()
    {
        string objectName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name.Equals("ShiningRockBear"))
        {
            if (rock.orientation == 1)
            {
                if (bearCutscene != null)
                {
                    bearCutscene.SetActive(true);
                    rock.orientation = 0;
                }

                barrier.SetActive(false);
                darkness.SetActive(false);
            }
        }

        if (gameObject.name.Equals("ShiningRockSalamander"))
        {
            if (rock.orientation == 3)
            {
                barrier.SetActive(false);
                darkness.SetActive(false);
            }
        }
    }
}

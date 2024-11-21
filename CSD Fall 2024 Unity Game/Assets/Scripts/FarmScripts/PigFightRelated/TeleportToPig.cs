using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TeleportToPig : MonoBehaviour
{
    private bool TEMP_CONDITION;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pig;
    [SerializeField] private GameObject ghostFox;
    [SerializeField] private GameObject door;
    [SerializeField] private Tilemap fences;

    private double penCenterX;
    private double penCenterY;

    private Vector3 initialScale;
    private Vector3 targetDoorScale;
    private bool scaleDoor;
    private float doorScaleSpeed;

    private float teleportDelay = 3.0f;

    // Start is called before the first frame update
    void Start () {
        TEMP_CONDITION = false;

        penCenterX = pig.transform.position.x;
        penCenterY = pig.transform.position.y;

        initialScale = door.transform.localScale;
        targetDoorScale = new Vector3 (51.0f, 84.26087f, 22.17391f);
        scaleDoor = true;
        doorScaleSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update () {
        if (TEMP_CONDITION) {
            if (scaleDoor) {
                if (door.transform.localScale.x < targetDoorScale.x) {
                    door.transform.localScale = Vector3.Lerp (door.transform.localScale, targetDoorScale, doorScaleSpeed * Time.deltaTime);
                } else {
                    door.transform.localScale = targetDoorScale;
                    scaleDoor = false;
                }
            } else {
                StartCoroutine (teleportAfterDelay ());
            }

        }
    }
    private IEnumerator teleportAfterDelay () {
        yield return new WaitForSeconds (teleportDelay);

        door.transform.position = new Vector3 (pig.transform.position.x, pig.transform.position.y, 0);
        player.transform.position = new Vector3 (pig.transform.position.x + 6, pig.transform.position.y, 0);
        ghostFox.transform.position = new Vector3 (pig.transform.position.x - 6, pig.transform.position.y, 0);

        fences.GetComponent<SpriteRenderer> ().sortingOrder = 10;
        pig.GetComponent<SpriteRenderer> ().sortingOrder = 10;
        player.GetComponent<SpriteRenderer> ().sortingOrder = 10;
        ghostFox.GetComponent<SpriteRenderer> ().sortingOrder = 10;
    }
}

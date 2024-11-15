using UnityEngine;

public class stopFox : MonoBehaviour
{
    public GameObject fox;
    private bool stop = false;
    private Rigidbody2D foxRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        foxRigidbody = fox.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            foxRigidbody.velocity = Vector2.zero; // Í£Ö¹ fox µÄËÙ¶È
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == fox)
        {
            Debug.Log("Fox has entered the trigger.");
            stop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == fox)
        {
            Debug.Log("Fox has exited the trigger.");
            stop = false;
        }
    }
}

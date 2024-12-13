using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMaze : MonoBehaviour
{
    [SerializeField] GameObject fox;
    // Start is called before the first frame update
    void Start()
    {
        fox = GameObject.Find("Fox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(fox))
        {
            SceneManager.LoadScene("Farm");
        }
    }
}

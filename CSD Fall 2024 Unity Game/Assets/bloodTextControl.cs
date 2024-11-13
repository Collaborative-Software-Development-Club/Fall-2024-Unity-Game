using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class bloodTextControl : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject textObject;
    private InputAction textAction;
    private InputAction buttonAction;
    public Vector2 position;
    bool isInitialF;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("EventText");
        text = GameObject.Find("EventText").GetComponent<TextMeshProUGUI>();
        GameObject.Find("EventText").SetActive(false);
        updateText();
        isInitialF = true;
    }

    //��ҿ���ȥ֮����ʾ��f����ʾѪ����һ�º�Ӱ��Ȼ��ڶ��ο���ȥ���ð�f���ֱ�ɷ��ѽ�
    void Update()
    {
        updateText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && isInitialF)
        {
            isInitialF = false;
            textObject.SetActive(true);

        }
        else if (!isInitialF)
        {
            textObject.SetActive(false);
        }
    }
    private void updateText()
    {
        if (isInitialF)
        {
            text.text = "* Someone's blood.*";
            text.color = Color.white;
        }
        else
        {
            text.text = "* IT's 0nly T0mat0 Sauce. *";
            text.color = Color.red;
        }
    }
}

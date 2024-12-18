using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningControl : MonoBehaviour
{
    public int warningThreshold; // The number of spores required to show the warning sign
    private int sporeCount;
    [SerializeField] private GameObject warningText;
    [SerializeField] private GameObject player;
    private TextMeshProUGUI warningTextComponent;

    // Start is called before the first frame update
    void Start()
    {
        // 获取 TextMeshProUGUI 组件
        warningTextComponent = warningText.GetComponent<TextMeshProUGUI>();

        if (warningTextComponent != null)
        {
            // 将初始透明度设置为 0（隐藏文字）
            Color color = warningTextComponent.color;
            color.a = 0f;  // 设置 alpha 通道为 0
            warningTextComponent.color = color;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on warningText!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 获取玩家的 Hallucination 组件中的 sporeCount
        sporeCount = player.GetComponent<Hallucination>().sporeCount;

        // 紒E槭欠翊丒搅随咦邮裤兄�
        if (sporeCount >= warningThreshold)
        {
            // 设置文本透明度为 1（蛠E煌该鳎�
            Color color = warningTextComponent.color;
            color.a = 1f;  // 设置 alpha 通道为 1
            warningTextComponent.color = color;
        }
        else
        {
            // 如果没有磥E姐兄担梢约绦３滞该鳎ǹ裳。�
            Color color = warningTextComponent.color;
            color.a = 0f;  // 设置 alpha 通道为 0
            warningTextComponent.color = color;
        }
    }
}

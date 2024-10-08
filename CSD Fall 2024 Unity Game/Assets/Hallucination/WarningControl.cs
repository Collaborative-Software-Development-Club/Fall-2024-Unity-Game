using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningControl : MonoBehaviour
{
    public int warningThreshold; // The number of spores required to show the warning sign
    private int sporeCount;
    public GameObject warningText;
    public GameObject sporeObject;
    public GameObject player;
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

        // 检查是否达到了孢子数量阈值
        if (sporeCount >= warningThreshold)
        {
            // 设置文本透明度为 1（完全不透明）
            Color color = warningTextComponent.color;
            color.a = 1f;  // 设置 alpha 通道为 1
            warningTextComponent.color = color;
        }
        else
        {
            // 如果没有达到阈值，可以继续保持透明（可选）
            Color color = warningTextComponent.color;
            color.a = 0f;  // 设置 alpha 通道为 0
            warningTextComponent.color = color;
        }
    }
}

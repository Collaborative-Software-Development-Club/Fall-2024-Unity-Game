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
        // ��ȡ TextMeshProUGUI ���
        warningTextComponent = warningText.GetComponent<TextMeshProUGUI>();

        if (warningTextComponent != null)
        {
            // ����ʼ͸��������Ϊ 0���������֣�
            Color color = warningTextComponent.color;
            color.a = 0f;  // ���� alpha ͨ��Ϊ 0
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
        // ��ȡ��ҵ� Hallucination ����е� sporeCount
        sporeCount = player.GetComponent<Hallucination>().sporeCount;

        // ��E��Ƿ�E�������������ֵ
        if (sporeCount >= warningThreshold)
        {
            // �����ı�͸����Ϊ 1��́E���͸����
            Color color = warningTextComponent.color;
            color.a = 1f;  // ���� alpha ͨ��Ϊ 1
            warningTextComponent.color = color;
        }
        else
        {
            // ���û�д�E���ֵ�����Լ�������͸������ѡ��
            Color color = warningTextComponent.color;
            color.a = 0f;  // ���� alpha ͨ��Ϊ 0
            warningTextComponent.color = color;
        }
    }
}

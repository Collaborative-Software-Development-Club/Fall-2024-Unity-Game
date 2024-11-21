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
        // »ñÈ¡ TextMeshProUGUI ×é¼ş
        warningTextComponent = warningText.GetComponent<TextMeshProUGUI>();

        if (warningTextComponent != null)
        {
            // ½«³õÊ¼Í¸Ã÷¶ÈÉèÖÃÎª 0£¨Òş²ØÎÄ×Ö£©
            Color color = warningTextComponent.color;
            color.a = 0f;  // ÉèÖÃ alpha Í¨µÀÎª 0
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
        // »ñÈ¡Íæ¼ÒµÄ Hallucination ×é¼şÖĞµÄ sporeCount
        sporeCount = player.GetComponent<Hallucination>().sporeCount;

        // ¼EéÊÇ·ñ´E½ÁËæß×ÓÊıÁ¿ãĞÖµ
        if (sporeCount >= warningThreshold)
        {
            // ÉèÖÃÎÄ±¾Í¸Ã÷¶ÈÎª 1£¨ÍE«²»Í¸Ã÷£©
            Color color = warningTextComponent.color;
            color.a = 1f;  // ÉèÖÃ alpha Í¨µÀÎª 1
            warningTextComponent.color = color;
        }
        else
        {
            // Èç¹ûÃ»ÓĞ´E½ãĞÖµ£¬¿ÉÒÔ¼ÌĞø±£³ÖÍ¸Ã÷£¨¿ÉÑ¡£©
            Color color = warningTextComponent.color;
            color.a = 0f;  // ÉèÖÃ alpha Í¨µÀÎª 0
            warningTextComponent.color = color;
        }
    }
}

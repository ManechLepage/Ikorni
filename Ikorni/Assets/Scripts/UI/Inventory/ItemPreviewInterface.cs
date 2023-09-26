using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPreviewInterface : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipment;
    public Player player;
    public ColorDatabase colorDatabase;
    [Space]
    [Header("Preview UI")]
    public Image spritePreview;
    public TextMeshProUGUI namePreview;
    public TextMeshProUGUI descriptionPreview;
    
    public void UpdateItemPreview()
    {
        ItemObject item = inventory.database.GetItem[player.mouseItem.lastClickedItem.item.ID];

        spritePreview.sprite = item.uiDisplay;
        spritePreview.color = new Color(1, 1, 1, 1);

        namePreview.text = item.itemName;
        descriptionPreview.text = EnrichText(item.description, item);
    }

    public string EnrichText(string text, ItemObject item)
    {
        string[] parts = text.Split('*');
        
        for (int i = 0; i < parts.Length; i++)
        {
            for (int j = 0; j < item.richText.Count; j++)
            {
                if (parts[i] == item.richText[j].text)
                {
                    parts[i] = $"<color=#{ColorUtility.ToHtmlStringRGB(colorDatabase.color[colorDatabase.colors.IndexOf(item.richText[j].color)])}>{parts[i]}</color>";
                }
            }
        }
        return string.Join(" ", parts);
    }

    public void ClearItemPreview()
    {
        spritePreview.sprite = null;
        spritePreview.color = new Color(1, 1, 1, 0);

        namePreview.text = "";
        descriptionPreview.text = "";
    }
}

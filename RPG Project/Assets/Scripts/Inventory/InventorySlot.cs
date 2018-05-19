using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public GameObject removePrompt;

    Item item;

    public void AddItem(Item _newItem)
    {
        item = _newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        removePrompt.SetActive(!removePrompt.activeSelf);
    }

    public void OnConfirmDelete()
    {
        Inventory.Instance.Remove(item);
        removePrompt.SetActive(!removePrompt.activeSelf);
    }

    public void OnCancelDelete()
    {
        removePrompt.SetActive(!removePrompt.activeSelf);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}

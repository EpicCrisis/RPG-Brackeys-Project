﻿using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        // Add to inventory.
        bool wasPickedUp = Inventory.Instance.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}

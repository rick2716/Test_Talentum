using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.EventSystems;

public class InventoryPlayerSlot : MonoBehaviour, IDropHandler
{
    public ItemType expectedType;
    public GameObject spawnPoint;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if(inventoryItem.item.type == expectedType)
            {
                inventoryItem.parentAfterDrag = transform;
                GameObject prefabItem = inventoryItem.item.prefab;
                GameObject spawnedPrefab = Instantiate(prefabItem, spawnPoint.transform.position, Quaternion.identity);
                spawnedPrefab.transform.parent = spawnPoint.transform;
            }
        }
    }
}

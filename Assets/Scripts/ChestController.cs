using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator animator;

    [Header("Inventory")]
    public InventoryManager inventoryManager;
    public ItemSO[] itemsToPick;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Open", true);
            inventoryManager.AddItem(itemsToPick[0]);
            inventoryManager.AddItem(itemsToPick[1]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontalInput;
    private float jumpInput;

    [Header("Inventory Access")]
    public GameObject inventoryPanel;
    public GameObject inGameUI;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        transform.Translate(new Vector2(horizontalInput, jumpInput) * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = !isOpen;
            OpenInventory();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
            transform.position = new Vector3(-6, -2, 0);
    }

    void OpenInventory()
    {
        if (isOpen)
        {
            inventoryPanel.SetActive(true);
            inGameUI.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(false);
            inGameUI.SetActive(true);
        }
    }
}

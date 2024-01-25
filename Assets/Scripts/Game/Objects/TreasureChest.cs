using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable
{
    public bool isOpen;
    private Animator anim;
    public GameObject thisLoot;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                // Open the chest
                OpenChest();
                MakeLoot();
            }
            else
            {
                // Chest is already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        // set the chest to opened
        isOpen = true;
        anim.SetBool("isOpened", true);
        
        
    }

    private void MakeLoot()
    {
        

        Instantiate(thisLoot.gameObject, transform.position, Quaternion.identity);
    }

    public void ChestAlreadyOpen()
    {
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = false;
        }
    }
}

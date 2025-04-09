using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactableObj = null;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Player entered Interact Object!");
            interactableObj = collision.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && interactableObj != null)
        {
            Debug.Log($"Hey, the player is now interacting with {interactableObj}");
            interactableObj.GetComponent<InteractionObject>().Interact(); 

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactableObj = null;
        }
    }
}

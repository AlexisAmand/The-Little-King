using UnityEngine.UI;
using UnityEngine;
using System.Runtime.InteropServices;

public class door : MonoBehaviour
{
    public GameObject doorGameObject;
    public Canvas doorUICanvas;

    private bool playerInRange;

    void Start()
    {
        doorUICanvas.enabled = false;
        playerInRange = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (Inventory.Instance.keysCount > 0)
            {
                // Player has enough keys, hide UI and destroy door object
                doorUICanvas.enabled = false;
                doorGameObject.SetActive(false);
                Inventory.Instance.RemoveKeys(1);
            }
            else
            {
                // Player does not have enough keys, show UI
                doorUICanvas.enabled = true;
                playerInRange = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player is no longer in range, hide UI
            doorUICanvas.enabled = false;
            playerInRange = false;
        }
    }

}

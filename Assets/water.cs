using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class water : MonoBehaviour
{

    private bool isPlayerInTrapZone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPlayerInTrapZone)
        {
            isPlayerInTrapZone = true;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.05f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrapZone = false;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
        }
    }

}
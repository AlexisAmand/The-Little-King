using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyShoot : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

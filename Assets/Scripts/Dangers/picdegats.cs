using UnityEngine;

/* Ce script gére les dégâts des pics sur le  player */

public class picdegats : MonoBehaviour

{
    public int picDamage = 15; /* Quantité de dégats */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(picDamage);
            Debug.Log("Ouuuh ça pique les fesses !");
        }
    }
}

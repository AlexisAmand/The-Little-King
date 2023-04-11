using UnityEngine;

public class Feu : MonoBehaviour
{
    public int fireDamage = 50; /* Quantité de dégats */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(fireDamage);
            Debug.Log("Je brûle !");
        }
    }
}

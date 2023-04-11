using UnityEngine;
public class SpikeDamage : MonoBehaviour 
{ 

    /* peut-être que ce script est inutile */

    public int damageIfPic = 33; /* Quantité de dégats */     

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageIfPic);
        }
    }

}
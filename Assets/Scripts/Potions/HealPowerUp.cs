using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int healthpoint;

    /* son pour la vie en + */
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Player"))
        {

            /* génération d'un nombre entre 0 et 20 pour une quantité de points de vie aléatoire */
            healthpoint = Random.Range(5, 25);
            Debug.LogWarning("Le joueur a répupéré " + healthpoint + "Points de vie");

            if (PlayerHealth.Instance.currentHealth != PlayerHealth.Instance.maxHealth)
            {
                // on joue le son
                AudioManager.Instance.PlayClipAt(pickupSound, transform.position);
                // rendre de la vie au joueur
                PlayerHealth.Instance.HealPlayer(healthpoint);
                // mettre à jour de dessin
                Destroy(gameObject);
            }
        }
    }

}

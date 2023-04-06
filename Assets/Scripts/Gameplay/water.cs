using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

// créé par mes soins, mais modifié par ChatGPT 3.5
// je ne suis pas sûr de l'intérêt de isPlayerInTrapZone

public class water : MonoBehaviour
{

    private bool isPlayerInTrapZone = false;
    public int healthpoint = 10;

    private WaitForSeconds loseInterval = new WaitForSeconds(3f);
    private WaitForSeconds winInterval = new WaitForSeconds(2f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPlayerInTrapZone)
        {
            isPlayerInTrapZone = true;
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.05f;

            // le joueur perd des points de vie à chaque entrée dans l'eau

            Debug.LogWarning("Le joueur a perdu " + healthpoint + "Points de vie");
            WaterHealth waterHealth = collision.transform.GetComponent<WaterHealth>();
            waterHealth.TakeDamage(healthpoint);

            // Lancer la coroutine qui fait perdre des points de vie au joueur
            StartCoroutine("TakeDamageOverTime", collision.gameObject);
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

        // Arrêter la coroutine qui fait perdre des points de vie au joueur
        StopCoroutine("TakeDamageOverTime");

        // Commence la coroutine pour restaurer l'oxygène du joueur
        StartCoroutine(RestoreOxygen());
    }

    /* cette coroutine a été écrite avec l'aide de ChatGPT 3.5 */
    /* elle enlève de l'oxygène à intervalle régulier */
    private IEnumerator TakeDamageOverTime(GameObject player)
    {
        while (isPlayerInTrapZone)
        {
            // Faire perdre des points de vie au joueur
            WaterHealth waterHealth = player.GetComponent<WaterHealth>();
            waterHealth.TakeDamage(healthpoint);

            // Attendre X secondes avant de faire perdre de nouveau des points de vie au joueur
            yield return loseInterval;
        }
    }

    /* cette coroutine rend de l'oxygène à intervalle régulier */
    private IEnumerator RestoreOxygen()
    {
        while (WaterHealth.Instance.currentOxygen < WaterHealth.Instance.maxOxygen)
        {

            /* On rend 10 points d'oxygene */
            WaterHealth.Instance.HealPlayer(healthpoint);
            Debug.LogWarning("Le joueur a gagné " + WaterHealth.Instance.currentOxygen + " Points d'oxygène");

            if (WaterHealth.Instance.currentOxygen > WaterHealth.Instance.maxOxygen)
            {
                WaterHealth.Instance.currentOxygen = WaterHealth.Instance.maxOxygen;
            }
            yield return winInterval;
        }
    }
}
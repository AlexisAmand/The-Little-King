using UnityEngine;

public class bridge : MonoBehaviour

{

    /* liste de gameobject et ensuite une sorte de foreach element in the list */

    public GameObject[] planches;

    public int damage = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            /* Le pont s'écroule */

            foreach (GameObject planche in planches)
            {
                planche.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }

            /* le player prend un peu de dégats */

            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);

            /* le nombre de dégat devient 0 */
            /* ça corrige un bug qui donnait des dégats quand le joueur arrive à l'emplacement du pont */
            /* surement que je peux enlever le damage = 0 ?? */

            // damage = 0;

            GetComponent<BoxCollider2D>().enabled = false;  

        }
    }

}
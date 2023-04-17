using UnityEngine;

// réalisé avec l'aide de ChatGPT 3.5

public class PoursuivreJoueur : MonoBehaviour
{

    public Transform player;
    public float speed = 5f;
    // public float range = 10f;

    public bool isInRange = false;
    public Animator animator;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 direction = (player.position - transform.position).normalized;
            // transform.position += direction * speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
            isInRange = true;
            animator.SetBool("isInRange", isInRange);

            /// On change le sens de l'ennemi en fonction de la position du joueur

            if (player.position.x > transform.position.x)
            {
                // Si la cible est à droite du personnage
                GetComponent<SpriteRenderer>().flipX = false; // Le sprite regarde vers la droite
            }
            else
            {
                // Si la cible est à gauche du personnage
                GetComponent<SpriteRenderer>().flipX = true; // Le sprite regarde vers la gauche
            }

        }
    }

    /* quand le joueur s'éloigne, on met isInRange sur false pour arrêter l'anim walk, et lancer celle idle */

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            animator.SetBool("isInRange", isInRange);
        }

    }

}

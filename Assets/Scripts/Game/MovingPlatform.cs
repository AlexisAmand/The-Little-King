using UnityEngine;

/* Ce script est en partie adapté de celui qui s'occupe du déplacemennt des ennemis */

public class MovingPlatform : MonoBehaviour
{
    public float speed; /* vitesse de déplacement de la plateforme */
    public Transform[] waypoints; /* liste de points vers lesquels la plateforme doit se déplacer */

    private Transform target; /* Cible vers laquelle la plateforme va se déplacer */
    private int destPoint = 0; /* le point de destination, sorte d'index */

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        /* Dans quelle direction faut-il déplacer la plateforme ? */
        Vector3 dir = target.position - transform.position;

        /* déplacement de la plateforme */
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        /* Si la plateforme est quasiment arrivé à sa destination */
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }

    }

    /* Les deux fonctions qui suivent corrigent le bug du perso sur la plateforme
     * Il reste dessus et la suit, plus besoin d'appuyer sur gauche/droite pour maintenir
     * le personnage dessus */
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}
using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{

    public float speed; /* vitesse de déplacement de l'ennemi */
    public Transform[] waypoints; /* liste de points vers lesquels l'ennemi doit se déplacer */

    public int damageOnCollision = 20; /* Quantité de dégats de la part d'un ennemi */

    public SpriteRenderer graphics; /* fait référence à la partie graphique de l'ennemi */
    private Transform target; /* Cible vers laquelle l'ennemi va se déplacer */
    private int destPoint = 0; /* le point de destination, sorte d'index */

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        /* Dans quelle direction faut-il déplacer l'ennemi ? */
        Vector3 dir = target.position - transform.position;

        /* déplacement de l'ennemi */
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        /* Si l'ennemi est quasiment arrivé à sa destination */
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];

            /* le personnage se tourne vers la direction où il va */
            graphics.flipX = !graphics.flipX;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth   = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }

}

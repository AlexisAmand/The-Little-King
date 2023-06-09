using UnityEngine;

/* Ce script g�re l'animation des pics � l'approche du player */

public class pieges : MonoBehaviour

{
    public bool isInRange = false;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /* On regarde si l'objet entre en contact avec la zone de piege et on d�marre l'anim */
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            animator.SetBool("isInRange", isInRange);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        /* On regarde si l'objet quitte la zone du piege et on arr�te l'anim */
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            animator.SetBool("isInRange", isInRange);
        }

    }
}
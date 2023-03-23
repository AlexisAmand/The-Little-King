using UnityEngine.UI;
using UnityEngine;

public class Chess : MonoBehaviour
{
    // va contenir le texte du canvas
    private Text interactUI;
    // le player est-il a proximit� ?
    private bool isInRange;
    // va contenir l'animation que l'on va jouer 
    public Animator animator;
    // r�compense
    public int coinsToAdd;
    // son � jouer au moment de la r�compense
    public AudioClip soundToPlay;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        // si on appuye sur la touche E et est � proximit�
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            // appel de la m�thode qui ouvre le coffre
            OpenChest();
        }
    }

    // m�thode qui ouvre le coffre
    void OpenChest()
    {
        // On met OpenChess d'Unity sur True pour que l'animation soit jou�e
        animator.SetTrigger("OpenChess");
        // On donne la r�compense au joueur
        Inventory.Instance.AddCoins(coinsToAdd);
        // On joue un son � la position o� le joueur est
        AudioManager.Instance.PlayClipAt(soundToPlay, transform.position);
        // On desactive le collider, comme �a le player ne peut plus interagir avec le coffre qui a �t� vid�
        GetComponent<BoxCollider2D>().enabled = false;
        // On masque le message
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On regarde si c'est bien le player qui est dans la zone
        if(collision.CompareTag("Player"))
        {
            // On affiche le message
            interactUI.enabled = true;
            // On signale que le player est � proximit� du coffre
            isInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // On regarde si c'est bien le player qui s'�loigne de la zone
        if (collision.CompareTag("Player"))
        {
            // On masque le message
            interactUI.enabled = false;
            // On signale que le player n'est plus � proximit�
            isInRange = false;

        }

    }
}

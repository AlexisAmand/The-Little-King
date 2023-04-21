using UnityEngine.UI;
using UnityEngine;

public class elevator : MonoBehaviour
{
    /* messsage qui indique qu'on est a côté de l'ascenseur */
    private Text interactUI; 

    private bool isInRange = false;

    public Transform elevatorBox; /* l'ascenseur */
    public float speed = 10f; /* vitesse de l'ascenseur */
    public int distance = 100; /* distance parcouru par l'ascenseur */

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("J'active l'ascenseur");

            /* le gameobject se deplace vers le haut pour simuler l'ascenseur qui monte */
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(elevatorBox.position.x, elevatorBox.position.y + distance), speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Je suis dans l'ascenseur");
        isInRange = true;
        interactUI.enabled = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Je ne suis pas dans l'ascenseur");
        isInRange = false;
        interactUI.enabled = false;
    }

}

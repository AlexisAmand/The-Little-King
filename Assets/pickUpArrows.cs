using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpArrows : MonoBehaviour
{

    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // on joue le son
            AudioManager.Instance.PlayClipAt(sound, transform.position);

            // on ajoute la flèche à l'inventaire
            Inventory.Instance.AddArrows(5);
            CurrentSceneManager.Instance.arrowsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}

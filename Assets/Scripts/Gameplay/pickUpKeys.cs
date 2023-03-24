using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpKeys : MonoBehaviour
{
    
    // son joué quand on ramasse une clé
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // on joue le son
            AudioManager.Instance.PlayClipAt(sound, transform.position);

            // on ajoute la clé à l'inventaire
            Inventory.Instance.AddKeys(1);
            CurrentSceneManager.Instance.keysPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class magicbox : MonoBehaviour
{

    // prefab qui va remplacer la caisse
    public Transform prefab;
    private Transform prefabInstance;

    // son car on ramasse un bonus
    public AudioClip pickupSoundBad;

    // nb de pieces aléatoire
    private int coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /* On regarde si l'objet entre en contact avec la zone de piege et on démarre l'anim */
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            prefabInstance = Instantiate(prefab, transform.position, transform.rotation);

            /* on déplace le préfab un peu vers le haut (selon y donc) */
            /* ces deux lignes ont été écrites avec l'aide de ChatGPT 3.5 */
            GameObject newPrefab = Instantiate(prefab, transform.position, transform.rotation).gameObject;
            newPrefab.transform.Translate(new Vector2(0f, 1f));
            Destroy(prefabInstance.gameObject);

            // ajout de 2 pieces dans l'inventaire
            coins = Random.Range(1, 6);
            Inventory.Instance.AddCoins(coins);
        }

    }

}

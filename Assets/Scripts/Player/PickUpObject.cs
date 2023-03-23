using UnityEngine;

public class PickUpObject : MonoBehaviour

{

    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // on joue le son
            AudioManager.Instance.PlayClipAt(sound, transform.position);

            // on ajoute la piece à l'inventaire
            Inventory.Instance.AddCoins(1);
            CurrentSceneManager.Instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);

        }
    }



}

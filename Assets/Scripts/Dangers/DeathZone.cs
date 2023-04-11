using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour

{

    // private Transform playerSpawn;
    private Animator fadeSystem;
    public AudioClip deathSound;
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    public IEnumerator ReplacePlayer(Collider2D collision)
    {
        AudioManager.Instance.PlayClipAt(deathSound, transform.position);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = CurrentSceneManager.Instance.respawnPoint; 
    }

}


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSpecificScene : MonoBehaviour  
{

    public string sceneName;
    private Animator fadeSystem;

    /* Gestion de l'ouverture de la porte */
    public Sprite sprite1; // porte fermée
    public Sprite sprite2; // porte ouverte
    public bool DoorClosed = true; // Elle est fermée ou ouverte ? Par défaut elle est fermée.
    private SpriteRenderer spriteRenderer; /* On récupére le spriterenderer pour pouvoir modifier le sprite tout à l'heure */

    public int CoinsGoal; /* Nombre de coins à trouver dans le niveau. Valeur à completer dans Unity */

    /* Son qui indique qu'on change de niveau */
    // public AudioClip levelEnd;
    /* Son qui indique que la porte s'ouvre */
    // public AudioClip doorOpen;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Accès au SpriteRenderer de l'objet

        /* Au chargement du niveau, on regarde si le nombre de piece est ok */
        if (Inventory.Instance.coinsCount >= CoinsGoal) 
        {
            openDoor();
        }
        
    }

    void Update()
    {
        /* Si toutes les pieces sont ramassées en cour de partie */
        if (Inventory.Instance.coinsCount == CoinsGoal) 
        {
            openDoor();
        }
    }

    void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void openDoor()
    {
        spriteRenderer.sprite = sprite2; /* On remplace le sprite */
        DoorClosed = false; /* La porte est maintenant ouverte */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if ((collision.CompareTag("Player")) && (DoorClosed == false))
        {
            /* la porte est ouverte ! Le joueur peut passer */
            Debug.Log("C'est ok pour la porte");
            StartCoroutine(loadNextScene());
        }      
    }

    public IEnumerator loadNextScene()
    {
        /* On joue le son du changement de scène */
        // AudioManager.Instance.PlayClipAt(levelEnd, transform.position);

        /* sauvegarde des données au passage de la porte de changement du niveau */
        LoadAndSaveData.Instance.SaveData();

        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour

{

    public GameObject gameOverUI; /* fait r�f�rence au menu */

    public static GameOverManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la sc�ne");
            return;
        }

        Instance = this;
    }

    /* A la mort du joueur, on affiche le menu */
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    // recommencer le niveau
    public void RetryButton()
    {
        Debug.Log("On essaie de r�essayer");

        Inventory.Instance.RemoveCoins(CurrentSceneManager.Instance.coinsPickedUpInThisSceneCount);
        // Recharge la sc�ne
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Replace le joueur au spawn
        // R�active les mouvements du joueur + qu'on lui rende sa vie
        PlayerHealth.Instance.Respawn();
        gameOverUI.SetActive(false);
    }

    // retour au menu principal
    public void MainMenuButton()
    {
        /* Charge le Main Menu */
        SceneManager.LoadScene("MainMenu");
    }

    // fermer le jeu
    public void QuityButton()
    {
        Application.Quit();
    }

}

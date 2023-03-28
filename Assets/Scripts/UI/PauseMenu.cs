using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /* Etat du jeu. Par défaut, il n'est pas en pause */
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            /* Si le jeu est en pause, on le reprend */
            if(gameIsPaused)
            {
                Resume();
            }
            /* Si le jeu n'est pas en pause, on active le menu pause */
            else
            {
                Paused();
            }
                 
        }
    }

    void Paused()
    {
        // on est en pause, le joueur n'a pas besoin de bouger 
        PlayerMovement.Instance.enabled = false;
        // afficher le menu pause
        pauseMenuUI.SetActive(true);
        // arrêter le temps dans le jeu
        Time.timeScale = 0;
        // changer le statut du jeu (variable gameIsPaused)
        gameIsPaused = true;
    }

    public void Resume()
    {
        // le joueur a à nouveau le droit de bouger
        PlayerMovement.Instance.enabled = true;
        // afficher le menu pause
        pauseMenuUI.SetActive(false);
        // arrêter le temps dans le jeu
        Time.timeScale = 1;
        // changer le statut du jeu (variable gameIsPaused)
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        Paused();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    /* fonction qui charge le Main Menu à la fin des crédits */

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /* Si on appuye sur ESC, ça skip les crédits et ça charge le Main Menu */

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // SceneManager.LoadScene("MainMenu");
            LoadMainMenu();
        }

    }
}

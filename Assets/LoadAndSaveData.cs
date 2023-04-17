
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        /* chargement des données sauvegardées */
        /* O est la valeur par défaut, si le joueur n'a pas encore joué */
        Inventory.Instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);

        /* mise à jour de l'interface avec les données issues de la sauvegarde */
        Inventory.Instance.UpdateTextUI();

        /* récup de la vie */
        /* par défaut, c'est 100 */
        int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.Instance.maxHealth);
        PlayerHealth.Instance.currentHealth = currentHealth;
        PlayerHealth.Instance.healthBar.SetHealth(currentHealth);

    }

    public void SaveData()
    {
        /* sauvegarde du nombre de pièces en passant la valeur */
        PlayerPrefs.SetInt("coinsCount", Inventory.Instance.coinsCount);

        /* sauvegarde du nombre de points de vie en passant la valeur */
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.Instance.currentHealth);

        /* sauvegarde du niveau atteint si le niveau atteint est un niveau qui n'a pas encore été débloqué */

        if(CurrentSceneManager.Instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.Instance.levelToUnlock);
        }

    }

}

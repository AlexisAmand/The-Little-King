using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    public int coinsPickedUpInThisSceneCount;
    public int keysPickedUpInThisSceneCount;

    public static CurrentSceneManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        Instance = this;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;

    public static DontDestroyOnLoadScene Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DontDestroyOnLoadScene dans la scène");
            return;
        }

        Instance = this;

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

}

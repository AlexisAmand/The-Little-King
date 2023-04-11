using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevelPassed(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
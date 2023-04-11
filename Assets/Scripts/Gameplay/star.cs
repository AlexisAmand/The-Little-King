using UnityEngine;

public class star : MonoBehaviour
{

    public GameObject littleStar;
    public GameObject lightStar;

    void Start()
    {
        littleStar.transform.localScale = new Vector3(4, 4, 4);
        lightStar.transform.localScale = new Vector3(4, 4, 4);
    }
}

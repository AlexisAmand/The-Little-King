using UnityEngine;

public class wall : MonoBehaviour
{
    public GameObject wallDesign;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            wallDesign.SetActive(false);
        }
    }

}
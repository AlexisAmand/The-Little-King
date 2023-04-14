using System.Collections;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowSpeed = 20f;
    public float fireRate = 0.5f;

    private bool isShooting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootArrow());
        }
    }

    private IEnumerator ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        // Disable arrow collider while shooting
        Collider2D arrowCollider = arrow.GetComponent<Collider2D>();
        arrowCollider.enabled = false;

        rb.velocity = arrowSpawnPoint.right * arrowSpeed;

        yield return new WaitForSeconds(fireRate);

        // Re-enable arrow collider
        arrowCollider.enabled = true;

        isShooting = false;
    }

}

// using UnityEngine.UI;
using UnityEngine;
// using System.Collections;

public class PlayerSpawn : MonoBehaviour
{
 
    /* Spawnage du player, on en profite pour afficher le titre du niveau via une coroutine */
    public void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }

}

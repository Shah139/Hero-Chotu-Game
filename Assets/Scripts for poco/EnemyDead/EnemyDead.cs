using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) // Triggered when the enemy collides with something
    {
        // Optional: Add a condition if you want the enemy to vanish only on specific collisions, e.g. with the player:
        // if (collision.gameObject.CompareTag("Player"))
        
        // Destroy the enemy game object
        Destroy(gameObject);
    }
}

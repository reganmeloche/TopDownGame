using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            FindObjectOfType<PlayerHealth>().LoseHealth(10);
        }
        Destroy(gameObject);
    }
    
}

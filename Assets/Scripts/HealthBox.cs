using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>()) {
            Destroy(gameObject);
            FindObjectOfType<PlayerHealth>().AddHealth(50);
        }

    }
}

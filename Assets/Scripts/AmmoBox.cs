using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>()) {
            Destroy(gameObject);
            FindObjectOfType<PlayerAmmo>().AddAmmo(10);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>()) {
            var speech = "Hello friend!";
            FindObjectOfType<DialogueController>().Activate(speech);
        }

    }
}

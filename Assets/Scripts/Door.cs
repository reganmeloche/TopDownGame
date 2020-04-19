using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject otherDoor;

    // 0: entrance at top, 1: at right,...
    [SerializeField] int entranceLocation = 0;

    private void Start() {
        var collider = gameObject.GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            StartCoroutine(GoThroughDoor(other));
        }
    }

    IEnumerator GoThroughDoor(Collider2D other) {
        yield return StartCoroutine(FindObjectOfType<GameController>().PauseForSeconds(1));
        other.transform.position = otherDoor.transform.position + GetOffset();
    }

    private Vector3 GetOffset() {
        float offsetVal = 1f;
        switch (entranceLocation) {
            case 0:
                return new Vector3(0, -offsetVal, 0);
            case 1:
                return new Vector3(-offsetVal, 0, 0);
            case 2:
                return new Vector3(0, offsetVal, 0);
            case 3:
            default:
                return new Vector3(offsetVal, 0, 0);

        }
    }
}

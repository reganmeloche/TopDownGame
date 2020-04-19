using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int health = 100;
    Transform bar;

    void Start() {
        bar = transform.Find("Bar");
        UpdateDisplay();
    }

    public int GetHealth() {
        return health;
    }

    public void LoseHealth(int val) {
        health = Mathf.Max(0, health - val);
        UpdateDisplay();
    }

    public void AddHealth(int val) {
        health = Mathf.Min(100, health + val);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        float healthF = (float)health / 100f;
        bar.localScale = new Vector3(healthF, 1,0);
    }
}

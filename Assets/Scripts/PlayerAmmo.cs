using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmo : MonoBehaviour
{
    int ammo = 10;
    Text ammoText;

    void Start() {
        ammoText = GetComponent<Text>();
        UpdateDisplay();
    }

    public int GetAmmo() {
        return ammo;
    }

    public void SpendAmmo(int val) {
        ammo -= val;
        UpdateDisplay();
    }

    public void AddAmmo(int val) {
        ammo += val;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        ammoText.text = ammo.ToString();
    }
}

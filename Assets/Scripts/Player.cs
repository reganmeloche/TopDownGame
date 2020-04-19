using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] float bulletDelaySeconds = 0f;

    PlayerAmmo ammoCont;

    private float direction;
    private bool isFiring = false;
    public Rigidbody2D rb;

    // Sprites
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;
    [SerializeField] Sprite upSprite;
    [SerializeField] Sprite downSprite;

    private void Start() {
        ammoCont = FindObjectOfType<PlayerAmmo>();
    }

    private void Update()
    {
        if (!FindObjectOfType<GameController>().IsPaused()) {
            Move();
            Fire();
        }
        
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && !isFiring && ammoCont.GetAmmo() > 0)
        {
            double rad = direction * Math.PI / 180f;
            var xPos = (float)Math.Cos(rad);
            var yPos = (float)Math.Sin(rad);

            var bulletPosition = new Vector3(
                transform.position.x + xPos * 0.8f, 
                transform.position.y + yPos * 0.8f);

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(xPos * bulletSpeed, yPos * bulletSpeed);
            StartCoroutine(ResetFire());
            isFiring = true;

            ammoCont.SpendAmmo(1);
        }
    }

    IEnumerator ResetFire()
    {
        yield return new WaitForSeconds(bulletDelaySeconds);
        isFiring = false;
    }

    private void Move()
    {
        var deltaX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        var deltaY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2(deltaX, deltaY);
        UpdateSprite(deltaX, deltaY);
    }

    private void UpdateSprite(float deltaX, float deltaY)
    {
        if (deltaX < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
            direction = 180;
        }
        else if(deltaX > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
            direction = 0;
        }
        else if (deltaY < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = downSprite;
            direction = 270;
        }
        else if (deltaY > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = upSprite;
            direction = 90;
        }
    }
}

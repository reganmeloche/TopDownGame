using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletSpeed = 6;
    [SerializeField] int waitTime = 3;
    [SerializeField] int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime() {
        var jitter = Random.Range(-1, 1);
        yield return new WaitForSeconds(waitTime + jitter);
        TryToShoot();
        StartCoroutine(WaitForTime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            Destroy(other.gameObject);
            health -=35;
            if (health <=0 ){
                Destroy(gameObject);
            }
        }
    }

    private void TryToShoot() {
        if (isOnCamera()) {
            var pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
            GameObject enemyBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            var pPos = FindObjectOfType<Player>().transform.position;
            var ePos = transform.position;
            var vec = pPos - ePos;
            vec.Normalize();
            enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(vec.x * bulletSpeed, vec.y * bulletSpeed);
        }
    }

    private bool isOnCamera() {
        var pos = gameObject.transform.position;
        var vpPos = Camera.main.WorldToViewportPoint(pos);
        return vpPos.x > -0.1 && vpPos.x < 1.1 && vpPos.y > -0.1 && vpPos.y < 1.1;
    }
}

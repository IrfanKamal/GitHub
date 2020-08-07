using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Global variabel
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float reloadTime = 2f;
    private bool bulletReady = true;
    private Bird bird;
    // Coroutine reload
    Coroutine CR_reload;

    private void Start()
    {
        bird = GetComponent<Bird>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!bird.IsDead() && Input.GetMouseButtonDown(1) && bulletReady)
        {
            SpawnBullet();
            bulletReady = false;
            CR_reload = StartCoroutine(IeReload());
        }
    }

    // Method me-spawn bullet
    void SpawnBullet()
    {
        // Mengecek bullet
        if (bulletPrefab != null)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.gameObject.SetActive(true);
        }
    }

    IEnumerator IeReload()
    {
        yield return new WaitForSeconds(reloadTime);
        bulletReady = true;
    }
}

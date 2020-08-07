using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    // Global variabel
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Bird bird;
    // Update is called once per frame
    void Update()
    {
        //Melakukan pengecekan burung mati atau tidak
        if (!bird.IsDead())
        {
            //menggerakan game object kesebelah kiri dengan kecepatan tertentu
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    // Ketika menabrak pipa
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mengecek apakah bertabrakan dengan pipa
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

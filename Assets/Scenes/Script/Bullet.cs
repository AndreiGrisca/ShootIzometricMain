using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
 
    public float timeDestroy = 3f;
    public float speed = 3f;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke("DestroyBullet", timeDestroy);
        
        rb.velocity = transform.up * speed; 
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
    }


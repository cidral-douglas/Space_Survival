using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] GameObject destroyEffect;
    [SerializeField] float lifeTime = 5.0f;
    [SerializeField] float speed = 15f;

    void Start()
    {
        Invoke("destroyProjectile", lifeTime);   
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void destroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float bulletDamage = 10f;

    void Awake()
    {
        //Ignore the collisions between its bullets and itself
        Physics.IgnoreLayerCollision(9, 12);
    }

    private void Start()
    {
        StartCoroutine(BulletTimeout());
    }

    IEnumerator BulletTimeout()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            // do damage here, for example:
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(bulletDamage);
            Debug.Log(collision);
            Destroy(gameObject);
        } else if (collision.gameObject.layer == 8) {
            Destroy(gameObject);
        }
    }
}

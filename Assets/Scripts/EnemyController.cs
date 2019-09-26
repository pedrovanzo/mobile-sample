using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    public float speed = 5;
    public bool dirRight = true;
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Time.deltaTime * speed * Vector2.right);
        }
        else
        {
            transform.Translate(Time.deltaTime* speed * Vector2.left);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("limits"))
        {
            dirRight = !dirRight;
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        if (other.tag == "MitoWeapon") {
            MovePlayer2D.mitoPoints += 20;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 100;
    public GameObject deathEffect;
    public GameObject enemy;
    public Vector3 rigid;
    private Collision2D collision;
    void Start()
    {
        rigid = transform.position;

    }
    public void TakeDamage(int damage)
    {


        health -= damage;

        if (health <= 0)
        {
            Die();
            ScoreEnemy.instance.AddPoint();
        }

    }

    void Die()
    {
        transform.position = rigid;
        health = 100;
        /*Destroy(gameObject);
          Instantiate(enemy, rigid, Quaternion.identity);
        */
    }



}


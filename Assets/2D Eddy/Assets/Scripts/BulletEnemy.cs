using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigid;
    private Transform Enemy;
    private int damage = 10;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (Enemy.localScale.x < 0)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigid.velocity = new Vector2(-speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.localScale.x < 0)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigid.velocity = new Vector2(-speed, 0);
        }

        Destroy(gameObject, .5f);
    }


    void OnTriggerEnter2D(Collider2D hitinfo)
    {

        Player killer = hitinfo.GetComponent<Player>();

        if (killer != null)
        {
            killer.TakeDamage(damage);
           
        }


    }
}

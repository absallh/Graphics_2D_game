using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyControl : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatdistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject ProjectTitle;
    private Transform player;
    private Transform enemy;
    bool facingRight = true;
    private Vector3 TheScale;
    private Vector2 BulletPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            rotate(); 
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatdistance)
        {
            rotate();  
            transform.position = this.transform.position;
        }

        else if (Vector2.Distance(transform.position, player.position) < retreatdistance) 
        {
            rotate();   
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        BulletPosition = transform.position;
        if (timeBtwShots <= 0)
        {
            if (transform.localScale.x > 0)
            {
                BulletPosition += new Vector2(-2f, 1.5f);
            }
            else
            {
                BulletPosition += new Vector2(2f, 1.5f);
            }
            Instantiate (ProjectTitle, BulletPosition, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }

        else 
        {
            if (transform.localScale.x > 0)
            {
                BulletPosition += new Vector2(-2f, 1.5f);
            }
            else
            {
                BulletPosition += new Vector2(2f, 1.5f);
            }
            timeBtwShots -= Time.deltaTime;
        
        }

        void flip() 
        {
            facingRight = !facingRight;
            TheScale = transform.localScale;
            TheScale.x *= -1;
            transform.localScale = TheScale;

        }

        void rotate() {

            if (player.position.x > transform.position.x  && facingRight)
            {
                flip();

            }
            else if (player.position.x < transform.position.x && !facingRight)
            {
                flip();
            }
        }

    }
}
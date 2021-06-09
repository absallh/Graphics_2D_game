using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed ;
    public Rigidbody2D rigid;
    private Transform player;
    private int damage = 10;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
       
      
        if (player.localScale.x > 0)
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

        if (player.localScale.x > 0 ) 

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

         Enemy killer = hitinfo.GetComponent<Enemy>();

       if (killer != null)
            
        {

            killer.TakeDamage(damage);
      
               
         

        }

       


    }
    
}
    


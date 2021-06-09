using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    private float movement = 0f;
    private Rigidbody2D  rigidbody;
    private Animator playerAnimation;
    private bool gun;
    private bool sword;
    public GameObject Bullet;
    Vector2 BulletPosition;
    public float FireRate = 0.5f;
    float NextFire = 0.0f;
   


   
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        sword = false;
        gun = false;
      
    }

    // Update is called once per frame
    void Update()
    {


        // Up/Down
        transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * speed);
        //Left/Right
        transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);

        //animation 
        movement = Input.GetAxis("Horizontal");
        if (movement < 0f)
        {
            //left
            transform.localScale = new Vector2(-1f, 1f);
            playerAnimation.SetFloat("Speed", Math.Abs(Input.GetAxis("Horizontal")));
            
        }
        else if(movement > 0f)
        {
            //right
            transform.localScale = new Vector2(1f, 1f);
            playerAnimation.SetFloat("Speed", Math.Abs(Input.GetAxis("Horizontal")));
           
        }
        else
        {
            //up/down
            playerAnimation.SetFloat("Speed", Math.Abs(Input.GetAxis("Vertical")));
        }


        //check if character holds gun and  space is clicked
        if (Input.GetKeyDown("space") && gun==true && Time.time>NextFire)
        {
            NextFire = Time.time+FireRate;

            ShootBullet();
            Debug.Log("space clicked");
        }

        //check if character holds sword and  space is clicked to attack
        if (Input.GetKeyDown("space") && sword == true)
        {
            playerAnimation.SetBool("swordAttack", true);
            //wait for 0.25 seconds then set swordAttack to false
            StartCoroutine(Wait());
            
        }


    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.25f);
        playerAnimation.SetBool("swordAttack", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //if character does not have gun or sword
        if (sword==false && gun==false)
        {
            if (collision.tag == "weapon")
            {
                
                playerAnimation.SetBool("sword",true);
                sword = true;
                Destroy(collision.gameObject);

            }
            else if (collision.tag == "gun")
            {
                
                playerAnimation.SetBool("gun", true);
                gun = true;
                Destroy(collision.gameObject);
            }
            playerAnimation.SetFloat("Speed", Math.Abs(Input.GetAxis("Horizontal")));
        } //if the character has sword but want to pick a gun
        else if(sword==true && collision.tag == "gun")
        {
            playerAnimation.SetBool("sword", false);
            playerAnimation.SetBool("gun", true);
            sword = false;
            gun = true;
            Destroy(collision.gameObject);
            playerAnimation.SetFloat("Speed", Math.Abs(Input.GetAxis("Horizontal")));
        }//if the character has gun but want to pick a sword
        else if(gun==true && collision.tag == "weapon")
        {
            playerAnimation.SetBool("sword", true);
            playerAnimation.SetBool("gun", false);
            sword = true;
            gun = false;
            Destroy(collision.gameObject);
            playerAnimation.SetFloat("Speed", Math.Abs(Input.GetAxis("Horizontal")));
        }
        
        
    }

    public void ShootBullet()
    {
        BulletPosition = transform.position;
        if (transform.localScale.x > 0) 
        {
            BulletPosition += new Vector2(2f, 1.5f);
        }
        else
        {
            BulletPosition += new Vector2(-2f, 1.5f);
        }
        Instantiate(Bullet, BulletPosition, Quaternion.identity);
       
    }


   

}



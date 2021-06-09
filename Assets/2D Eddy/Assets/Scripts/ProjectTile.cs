using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{

    public float speed;
    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        

    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(player.position.x, player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target,speed*Time.deltaTime);
       /*if (transform.position.x == target.x && transform.position.y == target.y) 
        {

            DestroyProjectTitle();
        
        }
      */
    }
  
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PLAYER"))
        {
            DestroyProjectTitle();
        }
    }


    void DestroyProjectTitle()
    {
        Destroy(gameObject);
    }
   */
}

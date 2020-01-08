using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public int CollisionCheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log(collision.collider.name);
    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollisionCheck++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CollisionCheck--;
    }
}

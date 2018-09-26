using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thisPlayer : MonoBehaviour {

    //no score in this script
    //made some of the declarations private
    //item is declared inside the OnCollisionEnter2D method

    public Rigidbody2D player;
    public int speed = 0;
    private Vector3 movement;

    private int number;
    private float x, y;
    private Vector3 pos;

    void Start()
    {
        number = Random.Range(1, 2);
        player = GetComponent<Rigidbody2D>();
        player.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        player.AddForce(movement * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //name is specific to each GameObject
        //when you destroy and instantiate, you'll produce a different name for every GameObject everytime 
        //tag helps to generalize all of them to items 

        if (collision.gameObject.tag == "item")
        {
            Destroy(collision.gameObject);

            x = Random.Range(-5f, 5f);
            y = Random.Range(-2f, 2f);
            pos = new Vector3(x, y, 0);

            //make sure that prefabs gem and cherry are under the Resources folder
            //make sure your items and prefabs have the appropriate tag
            //make sure that the prefabs have the appropriate Box Collider 
            //make sure that your player has the appropriate Box Collider
            if (number == 1)
            {
                GameObject item = Instantiate(Resources.Load("gem"), pos, Quaternion.identity) as GameObject;
            }
            if (number == 2)
            {
                GameObject item = Instantiate(Resources.Load("cherry"), pos, Quaternion.identity) as GameObject;
            }

            
         
        }
    }
}

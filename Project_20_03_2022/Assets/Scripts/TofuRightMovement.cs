using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TofuRightMovement : MonoBehaviour
{
    //Movement speed of Tofu_Rght
    public float rightMoveSpeed = -5f;

    //Using this to store any calculations or speed variables for the fianal transform.Translate line
    float velocity;

    //Bool checks for if the Tofu needs to stop
    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        //To ensure movement when spawned
        stop = false;
    }

    //Collision detection through entering any trigger enabled Box Collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If entering the Box Collider 2D of a GameObject with the tag "Player" then set stop to true
        if(collision.gameObject.tag == "Player")
        {
            stop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If stop is false then change velocity value to rightMoveSpeed
        if(stop == false)
        {
            velocity = rightMoveSpeed;
        }
        //If stop is true then stop all Tofu_Right velocity
        if(stop == true)
        {
            velocity = 0;
        }
        //Uses the current Velocity value and applies it to the Tofu_Right movement on the X axis
        transform.Translate(new Vector3(velocity, 0, 0) * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //To clear the force of gravity
    public float jumpForce = 20;

    //Gravity and gravity multiplier floats
    public float gravity = -9.81f;
    public float gravityScale = 5;

    //Using this to store any calculations or speed variables for the fianal transform.Translate line
    float velocity;

    //Bool checks for if the player is on the ground and if they've been killed
    public bool isGrounded;
    public bool isKill;

    //GameObject reference to store GameManagerObject
    GameObject gameManagerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        // To ensure Player doesn't fall at the beginning of the Game and can also gurantee a jump
        isGrounded = true;
        //To ensure Player is alive at the start of the game
        isKill = false;
    }

    //Collision detection through entering any trigger enabled Box Collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If entering the Box Collider 2D of a GameObject with the tag "Ground" then set isGrounded to true
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            //finds GameManagerObject in scene and gains access to its GameManager script component
            gameManagerGameObject = GameObject.Find("GameManagerObject");
            GameManager gameManagerScript = gameManagerGameObject.GetComponent<GameManager>();
            //the player is grounded on the tofu so set spawnOn to true to spawn the next tofu
            gameManagerScript.spawnOn = true;
        }
        //If entering the Box Collider 2D of a Gameobject with the tag "Kill" then set isKill to true
        if(collision.gameObject.tag == "Kill")
        {
            isKill = true;
            print("Game Over");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //If isKill is false then allow other actions
        if(isKill == false)
        {
            //If isGrounded is false then apply gravity to the Player
            if (isGrounded == false)
            {
                velocity += gravity * gravityScale * Time.deltaTime;
            }
            //If isGrounded is true then stop all Player velocity
            if (isGrounded == true)
            {
                velocity = 0;
            }
            //If the left mouse button is clicked down
            if (Input.GetMouseButtonDown(0))
            {
                //As long as the Player isGrounded allow the player to jump
                //Switch isGrounded to false to stop a second jump and allow gravity to be reapplied
                if (isGrounded == true)
                {
                    velocity = jumpForce;
                    isGrounded = false;
                }

            }
        }
        
        //If isKill is true then stop all Player Velocity
        if(isKill == true)
        {
            velocity = 0;
        }
        //Uses the current Velocity value and applies it to the Player movement on the Y axis
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

    }

    

}

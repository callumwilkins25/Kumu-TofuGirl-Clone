using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TofuKillLeft : MonoBehaviour
{
    //Collision detection through entering any trigger enabled Box Collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If entering the Box Collider 2D of a GameObject with the tag "Player" then access the TofuLeftMovement script from parent and set stop to true
        if (collision.gameObject.tag == "Player")
        {
            TofuLeftMovement parentScript = transform.parent.gameObject.GetComponent<TofuLeftMovement>();
            parentScript.stop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

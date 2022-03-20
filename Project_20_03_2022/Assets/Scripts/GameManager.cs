using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameObject references for prefabs
    public GameObject tofuBase;
    public GameObject player;
    public GameObject tofuLeft;
    public GameObject tofuRight;

    //Bool check for if spawning is on
    public bool spawnOn;

    //Counter for amount of tofu spawned
    public int spawnCount = 1;
    //Integer for next tofu spawn height
    public int tofuSpawnHeight;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiating tofu base and player as a start to the scene
        Instantiate(tofuBase);
        Instantiate(player);
        //Set spawnOn to true to spawn the first tofu
        spawnOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn method call
        Spawn();
    }
    //Method for spawning
    private void Spawn()
    {
        //if spawnOn is true then calculate what the next current tofu height should be multiplying the spawncount by 2
        if(spawnOn == true)
        {
            tofuSpawnHeight = spawnCount * 2;
            //random bool generation to randomize tofuLeft and tofuRight spawns
            bool randomBool = Random.value > 0.5;
            //if randomBool is true then spawn tofuLeft at set x axis value, y axis value should be calculated in tofuSpawnHeight
            if(randomBool == true)
            {
                Instantiate(tofuLeft, new Vector3(-8, tofuSpawnHeight, 0), Quaternion.identity);
                //add 1 to spawnCount and then set spawnOn to false
                spawnCount++;
                spawnOn = false;
            }
            //if randomBool is false then spawn tofuRight at set x axis value, y axis value should be calculated in tofuSpawnHeight
            if (randomBool == false)
            {
                Instantiate(tofuRight, new Vector3(8, tofuSpawnHeight, 0), Quaternion.identity);
                //add 1 to spawnCount and then set spawnOn to false
                spawnCount++;
                spawnOn = false;
            }
        }
    }
}

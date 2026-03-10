using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankSpawner : MonoBehaviour
{
    public GameObject tankPrefab;
    public int numberOfTanks = 0;
    public GameObject spawnedTank;

    public FirstScript tanksScript;

    public List<GameObject> tanks;
    public Transform barrel;

    public GameObject moonPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Instantiate a prefab: ,ake this one appear.
            //Instantiate a prefab, a Vector 2 or Vector 3, a Quaternion : make it appear at this position and rotation
            //USE THIS ONE
            spawnedTank = Instantiate(tankPrefab, transform.position, transform.rotation);

            //tanksScript = spawnedTank.GetComponent<FirstScript>();

            numberOfTanks++;

            //tanksScript.speed = numberOfTanks;
            //tanksScript.body.color = Random.ColorHSV();

            tanks.Add(spawnedTank);



            //Vector2 spawnPos = Random.insideUnitCircle * 5; 
            //Quaternion.identity means no rotation which the same same as Euler angles (0,0,0)
            //spawnedTank = Instantiate(tankPrefab, spawnPos, Quaternion.identity);

            Instantiate(moonPrefab, Random.insideUnitCircle * 5, Quaternion.identity );
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            tanks.Remove(spawnedTank);
            Destroy(spawnedTank);
        }

        //loop through everything in the tanks list: these are GameObjects
        //get that tanks transform
        //comapare that to the barrel: is the tank in the same position as the barrel?

        for (int i = tanks.Count - 1; i >= 0; i--)
        {
            float dist = Vector2.Distance(tanks[i].transform.position, barrel.position);
            if (dist < 0.5f)
            {
                Debug.Log("Explode tank" + i);
                //make a local variable to get a reference to the tank we want to destroy
                GameObject tank = tanks[i];
                //remove the tank from the list
                tanks.Remove(tank);
                //either of thesse work
                //tanks.RemoveAt(i);
                //destroy the tank
                Destroy(tank);
            }
        }



    }
}

//if (Mouse.current.rightButton.wasPressedThisFrame)
//{
//    //Instantiate a prefab, a Transform: makes it appear at 0,0 as the child of that transform
//    Instantiate(tankPrefab, transform);

//}

//loop through everything in the tanks list: these are GameObjects
//get hold of that game objects FirstScript component
//set the speed to be the numberOfTanks

//for(int i = 0; i < tanks.Count; i++)
//{
//    FirstScript ts = tanks[i].GetComponent<FirstScript>();
//    ts.speed = numberOfTanks;
//}

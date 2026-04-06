using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    Vector2 playerPos;
    float speed = 5;

    public Vector2 movement;
    Vector2 nextMovement;
    public GameObject cameraTracker;

    public Vector2 bottomLeft;
    public Vector2 topRight;

    public Vector2 roomSize;

    
    public List<Tilemap> walls;
    Vector3Int nextCell;
    Vector2 input;
    bool wallThere;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //was going to use room size to movew the camera, but for some reason theres a slight offset
        //for actual room size and the stored vector

        //topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        //roomSize = topRight * 2;
    }

    // Update is called once per frame 
    void Update()
    {
        //get screen size
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10));
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

        //call camera movement when player walks off the edge of the screen
        if (playerPos.x > topRight.x || playerPos.x < bottomLeft.x || 
            playerPos.y > topRight.y || playerPos.y < bottomLeft.y)
        {
            moveCam();
        }
  
        //player movement
        //assign input
        input = movement;

        //check next positon
        nextMovement = (Vector2)transform.position + input  * speed * Time.deltaTime;

        //loop through all the tilemaps in the walls list
        for (int i = 0; i < walls.Count; i++)
        {
            //get the cell of the next position in the current tilemap
            nextCell = walls[i].WorldToCell(nextMovement);
            Tile wallTile = (Tile)walls[i].GetTile(nextCell);
            Debug.Log("Checking cell: " + nextCell + " | Tile: " + wallTile);

            //checks if either tilemap has a wall tile in the next position, if it does then the player can't move
            if (wallTile != null)
            {
                wallThere = true;
                break;
            }
            else
            {
                wallThere = false;
            }
        }
        if (wallThere)
        {
            movement = Vector2.zero;
            Debug.Log("Wall in the way");
        }
        else
        {
            transform.position += (Vector3)movement * speed * Time.deltaTime;
            playerPos = transform.position;
        }
    }

    public void moveCam() 
    {
        //get the camera position from the camera tracker game object.
        Vector2 cameraPos = cameraTracker.transform.position; 
        //move camera to the right by the width of the screen when player moves off the right edge of the screen
        if (playerPos.x > topRight.x)
        {
            cameraPos.x += 16;
            cameraTracker.transform.position = cameraPos;
        }
        //move camera to the left by the width of the screen when player moves off the left edge of the screen
        else if (playerPos.x < bottomLeft.x)
        {
            cameraPos.x -= 16;
            cameraTracker.transform.position = cameraPos;
        }
        //move camera up by the height of the screen when player moves off the top edge of the screen
        else if (playerPos.y > topRight.y)
        {
            cameraPos.y += 10;
            cameraTracker.transform.position = cameraPos;
        }
        //move camera down by the height of the screen when player moves off the bottom edge of the screen
        else if (playerPos.y < bottomLeft.y)
        {
            cameraPos.y -= 10;
            cameraTracker.transform.position = cameraPos;
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //find out which way the player is trying to move and store it in a vector2
        movement = context.ReadValue<Vector2>();

        }

}

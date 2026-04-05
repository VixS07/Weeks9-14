using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    Vector2 playerPos;

    public Vector2 movement;
    public GameObject cameraTracker;

    public Vector2 bottomLeft;
    public Vector2 topRight;

    public Vector2 roomSize;

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
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10));
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

        transform.position += (Vector3)movement * 5f * Time.deltaTime;
        playerPos = transform.position;

        if(playerPos.x > topRight.x || playerPos.x < bottomLeft.x || 
            playerPos.y > topRight.y || playerPos.y < bottomLeft.y)
        {
            moveCam();
        }
    }

    public void moveCam() 
    {
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
        movement = context.ReadValue<Vector2>();
        
    }
}

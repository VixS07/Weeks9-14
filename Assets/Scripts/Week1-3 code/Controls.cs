using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public bool leftMousePressed = false;
    public bool rightMousePressed = false;
    public bool anyKeyPressed = false;

    public float speed = 10;
    public float rotationSpeed = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouse position
        //Camerra.main.SScrreenToWorrldPoint(Mouse.curent.position.RreadValue())

        //mouse input
        //is true all the time the button iss pressed
        leftMousePressed = Mouse.current.leftButton.isPressed;
        rightMousePressed = Mouse.current.rightButton.isPressed;

        //wasPresssedThisFrame is true for the first frame the button is pressed
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            Debug.Log("Left button pressed");
        }

        //wasPresssedThisFrame is true for the first frame the button is pressed
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("Right button pressed");
        }

        anyKeyPressed = Keyboard.current.aKey.isPressed;

        //test for left arrow key: move to the left
        if (Keyboard.current.leftArrowKey.isPressed) 
        {
            //just for my own curiosity: (it worked) transform.position -= transform.right * Time.deltaTime;
            //why teach us this shortcut if we dont use it? :'(
            //nevemind I just didnt get far enough in the vid lol
            Vector3 newRotation = transform.eulerAngles;
            newRotation.z += rotationSpeed * Time.deltaTime;
            transform.eulerAngles = newRotation;
        }
        //test for right arrow key: move to the right
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Vector3 newRotation = transform.eulerAngles;
            newRotation.z -= rotationSpeed * Time.deltaTime;
            transform.eulerAngles = newRotation;
        }
        //test for up arrow key: move up
        if (Keyboard.current.upArrowKey.isPressed)
        {
            //Vector2 newPos = transform.position;
            //newPos.y += speed * Time.deltaTime;
            //transform.position = newPos;
            transform.position += transform.up * speed * Time.deltaTime;
        }
        //test for down arrow key: move down
        if (Keyboard.current.downArrowKey.isPressed)
        {
            //Vector2 newPos = transform.position;
            //newPos.y -= speed * Time.deltaTime;
            //transform.position = newPos;
            transform.position -= transform.up * speed *  Time.deltaTime;
        }

    }
}

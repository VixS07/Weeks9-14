using UnityEngine;
using UnityEngine.InputSystem;

public class Flap : MonoBehaviour
{
    public bool up;
    //to starrt one of them at 5 to trigger the movement
    float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Make the t go up in seconds
        t += Time.deltaTime;

        //get the mouse position so the sprite can follow it
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //set the mouse position as the new position (allows us to edit the pos of the sprite relative to the mouse)
        Vector2 newPos = mousePos;

        //if t is more than 0 and up (meaning the sprite where the wings are flapped up) is true
        //reset the timer
        if (t > 0.3 && up) 
        { 
            t = 0;
            up = false;
        }
        //if the current sprite is the wings down one, move it back to the original position
        //this works because we start the sprite with the wing flapped down
        else if (t > 0.3)
        {
            t = 0;
            up = true;
        }

        
        if (up)
        {
            //move the ssprite off screen
            newPos.y += 20;
        } else if (!up){
            //move the sprite on screen
            newPos.y += 1;
        }

        //update the position
        transform.position = newPos;
    }
}

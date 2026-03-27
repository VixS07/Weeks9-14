using UnityEngine;
using UnityEngine.InputSystem;

public class Tester : MonoBehaviour
{
    float t;
    public bool yes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this script was used to test out different things because the bat stopped its flapping when i started using the mouse pos
        //this script is not actually on any objects, it was simply used for debugging and testing purposess

        t += Time.deltaTime;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 newPos = mousePos;

        //doesnt want to update the pos when i put it in here???
        //only does it for 1 frame
        if (t > 2 && !yes)
        {
            t = 0;
            yes = true;
            //newPos.x += 5;
        }
        else if (t>2 && yes) {
            t = 0;
            yes = false;
            //newPos.x = mousePos.x;
        }

        //changes it until the timer is up again :)
        if (yes)
        {
            newPos.x += 5;
        }
        else
        {
            newPos.x = mousePos.x;
        }

        transform.position = newPos;
    }
}

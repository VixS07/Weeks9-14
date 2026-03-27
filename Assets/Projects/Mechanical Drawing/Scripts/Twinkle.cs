using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Twinkle : MonoBehaviour
{
    public AnimationCurve curve;
    public float t;
    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //update the time in seconds
        t += Time.deltaTime;

        //get the possition
        Vector2 newPos = transform.position;
        //set the bottom left and bottom right to account for gamescreen size changes
        //got it from the FirstScript script
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //reset the time every 5 seconds to allow for a loop
        if (t > 2) {
            t = 0;
            //change the position to a random area within the screen
            //im doing unit circle because im not sure how to combine random with world screen position
            //if it works it works :')
            newPos = Random.insideUnitCircle * topRight.x;

            //I was going to do this but I think we did something like this in class week 3 and I dont want to risk it lol

            //Random.Range

        }

        

        //check to see if star has moved off screen, if it has bring it to the edge of the screen it went over.
        //x axis
        //left side
        if (newPos.x < bottomLeft.x)
        {
            newPos.x = bottomLeft.x;
        }
        //right side
        else if (newPos.x > topRight.x)
        {
            newPos.x = topRight.x;
        }
        //y axis
        //top
        else if (newPos.y < bottomLeft.y) 
        {
            newPos.y = bottomLeft.y;
        }
        else if (newPos.y > topRight.y)
        {
            newPos.y = topRight.y;
        }

        //make the stars move back slightly to keep the illusion of the bat flying
        if (t <= 2)
        {
            newPos.x -= 1 * Time.deltaTime;
        }

        //update pos
        transform.position = newPos;

        //change the scale of the star using the animation curve based on time.
        //got from the Pulse script
        transform.localScale = Vector3.one * curve.Evaluate(t);

    }
}

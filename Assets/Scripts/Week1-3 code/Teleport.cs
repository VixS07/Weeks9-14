using UnityEngine;

public class Teleport : MonoBehaviour
{

    float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t >= 3) {
            t = 0;

            Vector2 newPos = Random.insideUnitCircle * 10;

            //check for if it goes off screen
            //top edge
            if (newPos.y > 5) { 
                newPos.y = 5;
            }
            //bottom edge
            if (newPos.y < 0){ 
                newPos.y = 0;
            }
            //left edge
            if (newPos.x < 0) {
                newPos.x = 0;
            }
            //right edge
            if (newPos.x > 5)
            {
                newPos.x = 5;
            }

            //update pos
            transform.position = newPos;


        }
    }
}

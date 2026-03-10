using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float speed = 1f;
    //public SpriteRenderer body;

    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //speed = Random.Range(0.01f, 0.1f);
        transform.position = (Vector2)transform.position;

        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //test for the left edge
        if(screenPos.x < 0)
        {
            //set our world position to be the world space position under pixel 0 in X
            newPos.x = bottomLeft.x;
            //multiply the speed by -1
            speed = speed * -1;
        }
        //test for the right edge.
        if(screenPos.x > Screen.width)
        {
            //set our world position to be the world space position under pixel Screen.width in X
            newPos.x = topRight.x;
            //multiply the speed by -1
            speed = speed * -1;
        }

        transform.position = newPos;

    }
}

using UnityEngine;

public class Sky : MonoBehaviour
{
    Vector2 bottomLeft;
    Vector2 topRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        //get screen limits
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //scale the backroung(repurposed from first project) colour based on the screen size
        Vector2 newSize = transform.localScale;

        //make it dependent on the height and width
        newSize.x = topRight.x - bottomLeft.x;
        newSize.y = topRight.y - bottomLeft.y;

        //update scale
        //divide by 4 to make it fit the screen better, it was too big before
        //idk why it makes it huge but it does, so im just gonna divide it by 4 and call it a day
        transform.localScale = newSize/4;
    }
}

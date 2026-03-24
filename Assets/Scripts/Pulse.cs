using UnityEngine;

public class Pulse : MonoBehaviour
{
    Vector2 bottomLeft;
    Vector2 topRight;
    public int speed = 4;
    public float t;
    public AnimationCurve badum;
    public TrailRenderer trail;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        //move forward
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //check for right edge
        if(pos.x > topRight.x + 1)
        {
            //reset position
            trail.enabled = false;
            trail.Clear();
            pos.x = bottomLeft.x;
            transform.position = pos;
            trail.Clear();
            trail.enabled = true;
        }

        pos.y = badum.Evaluate(t) * 2;
        transform.position = pos;
    }
}

using UnityEngine;

public class Flicker : MonoBehaviour
{
    public AnimationCurve curve;
    public float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update time by seconds
        t+= Time.deltaTime;

        //reset the time every 2 seconds to allow for a loop
        if (t > 2) {
            t = 0;
        }

        //change the color of the sprite based on the curve and time
        GetComponent<SpriteRenderer>().color = new Color(curve.Evaluate(t), curve.Evaluate(t), curve.Evaluate(t), curve.Evaluate(t));
    }
}

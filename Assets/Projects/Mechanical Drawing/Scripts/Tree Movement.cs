using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float t;
    public AnimationCurve curve;
    public int seconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase the time in seconds
        t += Time.deltaTime;

        //when we hit 6 seconds, reset timer
        if (t > seconds)
        {
            t = 0;

        }

        //change the position based on an animation curve which loops based on the timer
        //got from the Linear Interpolation script
        transform.position = Vector2.Lerp(start.position, end.position, curve.Evaluate(t));
    }
}

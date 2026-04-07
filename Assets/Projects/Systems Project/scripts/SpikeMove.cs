using System.Collections;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public Transform spike;
    float height = 1;
    float yPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(IntoFloor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IntoFloor()
    {
        Debug.Log("lowering...");
        spike.localScale = new Vector2 (1, height);
        //y .5 of a change
        while (height > 0)
        {
            Debug.Log("being lowered...");
            height -= 1 * Time.deltaTime / 2;
            spike.localScale = new Vector2(1, height);
            while (yPos > 0.5)
            {
                yPos -= 1 * Time.deltaTime;
                spike.localPosition = new Vector2(spike.localPosition.x, (spike.localPosition.y - yPos));
            }
            yield return null;
        }
        if(height <= 0)
        {
            Debug.Log("done!");
        }
        
    }
}

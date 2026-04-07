using System.Collections;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public Transform spike;
    float height = 1;
    float yPos = 0;
    float moveAmount;
    public float moveMargin;
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
        while (height > 0 || yPos < moveMargin)
        {
            if (height > 0)
            {
                Debug.Log("being lowered...");
                height -= 1 * Time.deltaTime / 2f;
                if(height < 0)
                {
                    height = 0;
                }
                spike.localScale = new Vector2(1, height);
            }

            if (yPos < moveMargin)
            {
                moveAmount = 1 * Time.deltaTime / 4f;
                yPos += moveAmount;
                if(yPos > moveMargin)
                {
                    yPos = moveMargin;
                }
                spike.localPosition = new Vector2(spike.localPosition.x, (spike.localPosition.y - moveAmount));
            }
            yield return null;
        }
        if(height <= 0 && yPos >= moveMargin)
        {
            Debug.Log("done!");
        }
        
    }
}

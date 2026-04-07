using System.Collections;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public Transform spike;
    float height = 1;
    float yPos = 0;
    float moveAmount;
    public float moveMargin;

    Coroutine TheIntoFloorCoroutine;
    Coroutine TheOutOfFloorCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartMove();

    }

    public void StartMove()
    {
        if (TheIntoFloorCoroutine == null && TheOutOfFloorCoroutine == null)
        {
            if (height > 0)
            {
                TheIntoFloorCoroutine = StartCoroutine(IntoFloor());
            }
            else
            {
                TheOutOfFloorCoroutine = StartCoroutine(OutOfFloor());
            }
        }
        
   
    }

    public void StopMove()
    {
        if (TheIntoFloorCoroutine != null)
        {
            StopCoroutine(TheIntoFloorCoroutine);
            TheIntoFloorCoroutine = null;
        }
        if (TheOutOfFloorCoroutine != null)
        {
            StopCoroutine(TheOutOfFloorCoroutine);
            TheOutOfFloorCoroutine = null;
        }
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
                spike.localPosition = new Vector3(spike.localPosition.x, (spike.localPosition.y - moveAmount), spike.localPosition.z);
            }
            
            yield return null;
        }
        if(height <= 0 && yPos >= moveMargin)
        {
            Debug.Log("done!");
        }
        spike.localPosition = new Vector3(spike.localPosition.x, spike.localPosition.y, 0);
        height = 0;
        yPos = moveMargin;
        TheIntoFloorCoroutine = null;
    }

    IEnumerator OutOfFloor()
    {
        Debug.Log("raising...");
        while (height < 1 || yPos > 0)
        {
            if (height < 1)
            {
                Debug.Log("being raised...");
                height += 1 * Time.deltaTime / 2f;
                if (height > 1)
                {
                    height = 1;
                }
                spike.localScale = new Vector2(1, height);
            }
            if (yPos > 0)
            {
                moveAmount = 1 * Time.deltaTime / 4f;
                yPos -= moveAmount;
                if (yPos < 0)
                {
                    yPos = 0;
                }
                spike.localPosition = new Vector3(spike.localPosition.x, (spike.localPosition.y + moveAmount), spike.localPosition.z);
            }
            yield return null;
        }
        if (height >= 1 && yPos <= 0)
        {
            Debug.Log("done!");
        }
        spike.localPosition = new Vector3(spike.localPosition.x, spike.localPosition.y, 0);
        yield return new WaitForSeconds(10);
        height = 1;
        yPos = 0;
        TheOutOfFloorCoroutine = null;
    }
}

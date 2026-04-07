using System.Collections;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public Transform spike;
    float height = 1;
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

        if (height > 0)
        {
            Debug.Log("being lowered..."); 
            height -= 1 * Time.deltaTime;
            spike.localScale = new Vector2 (1, height);
            yield return null;
        }
        if(height == 0)
        {
            Debug.Log("done!");
        }
        
    }
}

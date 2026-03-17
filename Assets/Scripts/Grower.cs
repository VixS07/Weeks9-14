using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;
    public float applet = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;
        //StartCoroutine(GrowTree());
        //StartCoroutine(GrowApple());


        StartTreeGrowing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing() 
    {
        //StartCoroutine(GrowTree());
        //StartCoroutine(GrowApple());
        StartCoroutine(StartTheGrowing());
    }

    IEnumerator StartTheGrowing()
    {
        //we do it this way bc its all in one place, and you can put things inbetween the different yields.
        Debug.Log("Starting...");
        yield return StartCoroutine(GrowTree());
        Debug.Log("... tree finished, starting apple");
        yield return StartCoroutine(GrowApple());
        Debug.Log("...Done!");
    }

    IEnumerator GrowTree() 
    {
        Debug.Log("Started the tree");
        float t = 0;
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Finished the tree");
        //one way to do it
        //StartCoroutine(GrowApple());
    }

    IEnumerator GrowApple()
    {
        Debug.Log("Started the apple");
        float t = 0;

        appleTransform.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Finished the apple");
    }
}

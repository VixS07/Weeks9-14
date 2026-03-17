using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform treeTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeTransform.localScale = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrowTree() 
    {
        float t = 0;

        while (t > 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
        }
    }
}

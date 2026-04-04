using UnityEngine;

public class camMovement : MonoBehaviour
{
    public float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        t += Time.deltaTime;
        if(t > 2)
        {
            t = 0;
            Vector3 pos = transform.position;
            pos.x -= 16;
            transform.position = pos;
        }
    }
}

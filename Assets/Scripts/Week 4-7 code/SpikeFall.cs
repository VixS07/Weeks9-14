using NUnit.Framework.Internal;
using UnityEngine;

public class SpikeFall : MonoBehaviour
{
    //public bool falling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fall(bool falling)
    {
        float t =+ Time.deltaTime;

        Vector2 pos = transform.position;

        if (falling && t<5)
        {
            pos.y -= 1 * Time.deltaTime;
            transform.position = pos;

        }

    
    }


}

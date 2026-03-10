using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{

    public float speed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.right is like new Vector3 (1,0,0)
        //transform.up is like new Vector3  (0,1,0)
        //transform.forward is like new Vector3(0,0,1);
        transform.position += transform.up *speed *  Time.deltaTime;
      
    }
}

using UnityEngine;

public class SpinMoth : MonoBehaviour
{
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spin = transform.eulerAngles;
        spin.z += speed;
        transform.eulerAngles = spin;
    }

    public void StartSpin()
    {
        speed = 100;
    }

    public void StopSpin()
    {
        speed = 0;
    }
}

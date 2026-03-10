using UnityEngine;

public class Drive : MonoBehaviour
{
    public AudioClip beep;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z += 270;
        transform.eulerAngles = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 carPos = transform.position;


        carPos.x += 4 * Time.deltaTime;

        //update pos
        transform.position = carPos;


    }
}

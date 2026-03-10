using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnMoose : MonoBehaviour
{
    GameObject Moose;

    Vector2 bottomLeft;
    Vector2 topRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Spawn();
        }
    }
    
    public void Spawn()
    {
        Vector2 spawnPos = Random.insideUnitCircle * 5;
        Instantiate(Moose, spawnPos, Quaternion.identity);

        //left edge
        if (spawnPos.x < bottomLeft.x)
        {
            spawnPos.x = bottomLeft.x;
        }
        //right edge
        else if (spawnPos.x > topRight.x)
        {
            spawnPos.x = topRight.x;
        }
        //top edge
        else if (spawnPos.y > topRight.y)
        {
            spawnPos.y = topRight.y;
        }
        //bottom edge
        else if (spawnPos.y < bottomLeft.y)
        {
            spawnPos.y = bottomLeft.y;
        }
    }
}

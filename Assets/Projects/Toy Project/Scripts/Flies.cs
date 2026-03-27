using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Flies : MonoBehaviour
{
    //movement
    public float speedX;
    public float speedY;
    float t = 3;

    Vector2 bottomLeft;
    Vector2 topRight;

    //health
    public Slider healthBar;
    public SpriteRenderer fly;
    public int health = 6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 flyPos = transform.position;
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //get screen limits
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //increase time by seconds
        t += Time.deltaTime;

        //get fly position
        Vector2 flyPos = transform.position;

        //every 3 seconds, set a random direction using speed
        //set a random rotation
        if (t > 3)
        {
            //random speed between -3 and 3 for both x and y
            speedX = Random.Range(-3, 4);
            speedY = Random.Range(-3, 4);
            Vector3 newRotation = transform.eulerAngles;
            newRotation.z += Random.Range(0, 360);
            transform.eulerAngles = newRotation;
            //reset time
            t = 0;
        }

        //add the speed onto the position
        flyPos.x += speedX * Time.deltaTime;
        flyPos.y += speedY * Time.deltaTime;
        //update position
        transform.position = flyPos;

        //when fly hits the wall, randomize speed again in appropiate direction
        if (flyPos.x <= bottomLeft.x)
        {
            speedX = Random.Range(1, 2);
        }
        else if (flyPos.x >= topRight.x)
        {
            speedX = Random.Range(-1, -2);
        }
        else if (flyPos.y >= topRight.y)
        {
            speedY = Random.Range(-1, -2);
        }
        else if (flyPos.y <= bottomLeft.y)
        {
            speedY = Random.Range(1, 3);
        }

        //get mouse pos, then check if player is clicking the fly
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (fly.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame) 
        {
            //lower health
            health--;

            //when health is at 0, make in invisible (object will be destroyed in the flySpawner script since it holds the list)
            if(health == 0)
            {
                gameObject.SetActive(false);
            }
        }
        //update health bar
        healthBar.value = health;
    }
}

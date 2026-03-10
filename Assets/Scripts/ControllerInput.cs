using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 movement;
    public AudioSource SFX;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (Vector3) movement * speed * Time.deltaTime;
        transform.position = movement;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("attack " + context.phase);
        if (context.performed)
        {
            SFX.Play();
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //the same as Mouse.current.position.ReadValue();
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
    
}

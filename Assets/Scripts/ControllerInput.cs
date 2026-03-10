using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 movement;
    public Vector2 looking;
    public AudioSource SFX;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for mvoement
        //transform.position += (Vector3) movement * speed * Time.deltaTime;

        //for mouse
        //transform.position = movement;

        //for look
        transform.eulerAngles = (Vector3)looking * speed * Time.deltaTime;

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
    
    public void OnLook(InputAction.CallbackContext context)
    {
        looking = context.ReadValue<Vector2>();
    }
}

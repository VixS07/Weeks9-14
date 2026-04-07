using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public LocalMultiplayerManager manager;

    public Vector2 movementInput;
    public float speed = 5;

    public AnimationCurve squeeze;
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player "+ playerInput.playerIndex + " attack");
            manager.PlayerAttacking(playerInput);
            StartCoroutine(Squish());
        }
    }

    IEnumerator Squish()
    {
        float t = 0;

        t += Time.deltaTime;
        transform.localScale = Vector2.one * squeeze.Evaluate(t);
        yield return null;
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public LocalMultiplayerManager manager;
    public AudioSource audioSouce;
    public AudioClip attackSFX;

    public Vector2 movementInput;
    public float speed = 5;

    public AnimationCurve squeeze;
    float t = 0;
    float tDash = 0;
    Coroutine theSquishCoroutine;
    Coroutine theDashCoroutine;
    public TrailRenderer trailRenderer;
    private void Start()
    {
        trailRenderer.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
        Debug.Log(speed);
        Debug.Log(tDash);
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
            if (theSquishCoroutine != null)
            {
                StopCoroutine(theSquishCoroutine);
            }
            theSquishCoroutine = StartCoroutine(Squish());

            audioSouce.clip = attackSFX;
            audioSouce.Play();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Interacting");

            if(theDashCoroutine != null)
            {
                StopCoroutine (theDashCoroutine);
            }
            trailRenderer.Clear();
            theDashCoroutine = StartCoroutine(Dash());
        }
    }

    IEnumerator Squish()
    {
        t = 0;
        while (t < 5)
        {
            t += Time.deltaTime;
            transform.localScale = Vector2.one * squeeze.Evaluate(t);
            yield return null;
        }

    }

    IEnumerator Dash()
    {
        Debug.Log("Dashing");
        tDash = 0;
        trailRenderer.enabled = true;
        speed = 10;
        while (tDash < 1)
        {
            tDash += Time.deltaTime;
            yield return null;
        }
        speed = 5;
        trailRenderer.enabled = false;
        
    }

}

using UnityEngine;
using UnityEngine.Events;

public class Contact : MonoBehaviour
{
    public SpriteRenderer player;
    public UnityEvent onPlayerTouch;
    public UnityEvent onPlayerLeave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.bounds.Contains(transform.position))
        {
            onPlayerTouch.Invoke();
        }
        else
        {
            onPlayerLeave.Invoke();
        }
    }

    public void DeleteSelf()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public SpriteRenderer player;
    public int health = 5;
    public AudioSource audioSource;
    public AudioClip chompSFX;
    public AudioClip deathSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //get the mouse pos
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //is it inside the sprite?, are they clicking?
        if (player.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Y: reduce health
            health--;
            //play a sound

            if (health == 0)
            {
                //set SFX to death
                //play SFX

                //makes it play through
                //audioSource.PlayOneShot(deathSFX);

                audioSource.clip = deathSFX;
                audioSource.Play();
                gameObject.SetActive(false);
            }
            else {
                //set SFX to chomp
                //play chomp SFX
                audioSource.clip = chompSFX;
                audioSource.Play();
            }
        }

        //update the health bar with our new health value
        healthBar.value = health;
    }

    public void resetHealth()
    {
        //turrn on the player game object
        gameObject.SetActive(true);

        //reset health to 5
        health = (int)healthBar.maxValue;

        //set the value of th slider to our health
        healthBar.value = health;
       
    }
}

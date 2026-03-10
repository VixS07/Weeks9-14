using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color col;
    public List<Sprite> barrels;
    public int randomNumber;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //PickARandomColour();
        PickARandomSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Debug.Log("Try to change the sprite");
            //PickARandomColour();
            if (barrels.Count > 0) 
            { 
                PickARandomSprite();
            }
        }

        //get the mouse position (in pixels)
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //is it over the shape
        if (spriteRenderer.bounds.Contains(mousePos))
        {
            //Y: set the colour with out col variable
            spriteRenderer.color = col;
        }
        else
        {
            //N: set the colour to white
            spriteRenderer.color = Color.white;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && barrels.Count > 0) 
        {

            barrels.RemoveAt(0);
        }
    }

    void PickARandomColour()
    {
        spriteRenderer.color = Random.ColorHSV();
    }

    void PickARandomSprite() 
    {
        //spriteRenderer.sprite = mySprite;

        //Pick a random number
        randomNumber = Random.Range(0, barrels.Count);
        //use that number to choose a sprite
        //assign that sprite to the sprite renderer
        spriteRenderer.sprite = barrels[randomNumber];
    }
}

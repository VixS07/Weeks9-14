using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIDemo : MonoBehaviour
{

    SpriteRenderer sr; //the square sprite in the world
    public Image mothImage; //the ducky image in the UI
    public int howManyClicks = 0;
    public TextMeshProUGUI score;
    public Slider slider;
    public TextMeshProUGUI sliderDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        score.text = howManyClicks.ToString();

        slider.wholeNumbers = true;
        slider.value = 2;
    }

    // Update is called once per frame
    void Update()
    {
        sliderDisplay.text = slider.value.ToString();
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            ChangeColour();
        }
    }

    public void ChangeColour()
    {
        sr.color = Random.ColorHSV();
        mothImage.color = sr.color;
    }

    public void setScaleBig(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }

    public void countClickss()
    {
        howManyClicks++;
        score.text = howManyClicks.ToString();
    }
}

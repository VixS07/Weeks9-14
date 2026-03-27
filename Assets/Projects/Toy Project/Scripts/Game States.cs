using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStates : MonoBehaviour
{
    public FlySpawn flies;
    public FlySpawn moths;
    public GameObject flySpawner;
    public GameObject mothSpawner;
    public int score;
    public TextMeshProUGUI scoreDisplay;
    public GameObject win;
    public GameObject mothman;

    //timer
    public float t = 0;
    public float timerMaxValue = 60;
    public Slider timerVisuals;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //update timer
        t += Time.deltaTime;
        timerVisuals.value = t;

        //score updater (win screen)
        //get flies killed
        flies = flySpawner.GetComponent<FlySpawn>();
        score = flies.fliesKilled + moths.fliesKilled;
        scoreDisplay.text = score.ToString();
        //when timer is over show win screen
        if(t >= 60)
        {
            win.SetActive(true);
        }
        //get moths killed
        moths = mothSpawner.GetComponent<FlySpawn>();
        //if 3 moths killed, display mothman screen
        if(moths.mothsKilled >= 3)
        {
            mothman.SetActive(true);
        }
    }

    public void Reset()
    {
        //reset timer
        t = 0;
        timerVisuals.value = t;
        //reset score
        score = 0;
        scoreDisplay.text = score.ToString();
        //hide win screen
        win.SetActive(false);
        //hide mothman screen
        mothman.SetActive(false);
    }
}

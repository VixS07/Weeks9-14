using System.Collections.Generic;
using UnityEngine;

public class FlySpawn : MonoBehaviour
{
    public GameObject bugPrefab;
    public GameObject spawnedBug;
    public List<GameObject> bugs;
    public float spawnRate;
    public float t;
    public Flies bugScript;
    public int fliesKilled;
    public int mothsKilled;
    public bool isFly;
    Vector2 bottomLeft;
    Vector2 topRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //get screen limits
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //spawn flies every 5 seconds
        t += Time.deltaTime;

        //get fly pos
        Vector2 bugPos = transform.position;

        //summon bugs
        if (t >= spawnRate && bugs.Count <= 100)
        {
            //spawn at random pos
            bugPos.x = Random.Range(bottomLeft.x-1, topRight.x+1);
            //make it spawn above the screen so the spawning looks organic
            bugPos.y = topRight.y + 1;
            transform.position = bugPos;
            spawnedBug = Instantiate(bugPrefab, transform.position, Quaternion.identity);
            bugs.Add(spawnedBug);
            t = 0;
            
        }

        //loop through list of bugs
        for (int i = bugs.Count - 1; i >=0; i--)
        {
            //get the script for each item in the list
            bugScript = bugs[i].GetComponent<Flies>();
            //check if the health is at 0 (the fly is dead)
            //if so, destory the object
            if (bugScript.health == 0)
            {

                //Debug.Log(i + "dead");
                GameObject bug = bugs[i];
                bugs.Remove(bug);
                Destroy(bug);
                //if its a fly, add to the flies killed, if its a moth, add to the moths killed and subtract from flies killed (flies killed is the score, so killing a moth lowers the score)
                if (isFly)
                {
                    fliesKilled += 20;
                }
                else
                {
                    mothsKilled++;
                    fliesKilled -= 10;
                }
            }

        }
    }

    public void Reset()
    {
        //reset flies and moths killed
        fliesKilled = 0;
        mothsKilled = 0;
        //reset spawn timer
        t = 2;
        //destroy all the bugs in the list, then clear the list
        for (int i = bugs.Count - 1; i >= 0; i--)
        {
            GameObject bug = bugs[i];
            bugs.Remove(bug);
            Destroy(bug);
        }
    }
}

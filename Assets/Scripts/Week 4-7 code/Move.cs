using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    public List<GameObject> cars;
    public GameObject carPrefab;
    public GameObject spawnedCar;
    public float t;

    public GameObject moth;

    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Vector2 carPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Vector2 carPos = transform.position;

        t += Time.deltaTime;
        if (t > 1 && cars.Count <= 10)
        {
            carPos.x = bottomLeft.x - 2;
            carPos.y = Random.Range(-3,3);
            transform.position = carPos;
            spawnedCar = Instantiate(carPrefab, transform.position, Quaternion.identity);
            cars.Add(spawnedCar);
            t = 0;

        }

        for (int i = 0; i < cars.Count; i++)
        {
            //loop cars once they pass the edge of the screen
            if (cars[i].transform.position.x > topRight.x + 2)
            {

                Debug.Log("Passed");
                carPos.x = bottomLeft.x - 2;
                carPos.y = Random.Range(-3, 3);

                cars[i].transform.position = carPos;

                transform.position = carPos;
            }

            //check for moth collision
            Vector2 mothPos = moth.transform.position;
            float dist = Vector2.Distance(cars[i].transform.position, mothPos);
            if (dist < 0.5f)
            {
                Debug.Log("crash");
                mothPos.x = 0;
                mothPos.y = bottomLeft.y + 1;
                moth.transform.position = mothPos;
               
            }
        }
    }
}

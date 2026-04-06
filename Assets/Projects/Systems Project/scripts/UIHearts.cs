using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIHearts : MonoBehaviour
{
    public List <GameObject> ListOfHearts;
    public GameObject heartPrefab;
    public GameObject newHeart;
    GameObject heartToRemove;
    bool triggered;
    public float dist;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddHeart()
    {
        newHeart = Instantiate(heartPrefab, transform);
        Vector2 heartPos = newHeart.transform.position;
        heartPos.x += ListOfHearts.Count * dist;
        newHeart.transform.position = heartPos;
        ListOfHearts.Add(newHeart);
        Debug.Log(ListOfHearts.Count);
    }

    public void RemoveHeart()
    {
        if (ListOfHearts.Count > 0 && !triggered)
        {
            triggered = true;
            heartToRemove = ListOfHearts[ListOfHearts.Count - 1];
            ListOfHearts.Remove(heartToRemove);
            Destroy(heartToRemove);
            Debug.Log(ListOfHearts.Count);
        }
    }

    public void ResetTrigger()
    {
        triggered = false;
    }
}

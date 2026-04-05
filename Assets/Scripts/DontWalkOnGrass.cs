using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class DontWalkOnGrass : MonoBehaviour
{
    public List<Vector2> movementPoints;

    public Tilemap tilemap;
    public Tile grass;
    Vector2 newPos;
    Vector3Int cell;

    float t;
    Coroutine lerpCR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementPoints = new List<Vector2>();
        movementPoints.Add(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        cell = tilemap.WorldToCell(mousePos);
        newPos = tilemap.GetCellCenterWorld(cell);
    }

    public void OnClick(InputAction.CallbackContext context) 
    {
        Debug.Log(context.phase);
        if (context.performed)
        {
            if (tilemap.GetTile(cell) != grass)
            {
                t = 0;
                
                StartCoroutine(LerpMove());
            }
        }
        
     }

    IEnumerator LerpMove()
    {
        Vector2 endPos = newPos;
        Vector2 startPos = transform.position;
        while (t <=1)
        {
            t += Time.deltaTime * 0.5f;

            transform.position = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}

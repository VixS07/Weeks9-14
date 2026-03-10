using UnityEngine;

public class Toggle : MonoBehaviour

{
    public void ToggleShape()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        //if the game object is inactive (turned off): call setactive and pass true
        //if (!gameObject.activeInHierarchy)
        //{
        //    gameObject.SetActive(true);
        //}
        ////otherwise (game object is active) : call setactive and pass false
        //else if (gameObject.activeInHierarchy) 
        //{
        //    gameObject.SetActive(false);
        //}



    }
}

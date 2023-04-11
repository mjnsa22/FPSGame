using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideDuringPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager manager;


    private void Update()
    {
        if (manager.gameState == GameManager.GameState.Playing)
        {
            GetComponent<CanvasGroup>().alpha = 0.0f;//if the game is playing, hide the ui elements
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(GetComponent<CanvasGroup>().alpha, 1.0f, 0.01f);//otherwise show them with a fade in
        }
    }
}

        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderboard : MonoBehaviour
{
    public GameManager manager;
    private ScoreManager scoreManager;
    private TMPro.TextMeshProUGUI timerMesh;

    private GameManager.GameState old_state;

    private void Start()
    {
        scoreManager = manager.GetComponent<ScoreManager>();
        timerMesh = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Update()
    {
        if (manager.gameState != old_state)//if the state of the game changes, 
        {
            Display();//update leaderboard
        }
        old_state = manager.gameState;
    }

    public void Display()
    {
        scoreManager.LoadScoresFromFile();//get scores from file
        string result = "Leaderboard";
        for (int i = 0; i < scoreManager.highScores.Length; i++)//loop through scores
        {
            float score = scoreManager.highScores[i];  
            if (score != 0)//if the score is valid
            {
                result = result + "\n"+(i+1)+") " + score;//display the result in leaderboard
            }
        }
        timerMesh.text = result;
    }
}

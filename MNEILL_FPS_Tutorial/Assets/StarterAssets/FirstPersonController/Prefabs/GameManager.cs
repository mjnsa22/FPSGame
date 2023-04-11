using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject timer;
    private TMPro.TextMeshProUGUI timerMesh;
    public ScoreManager scoreManager;
    public GameObject player;
    public List<GameObject> targets = new List<GameObject>();

    float gameTimer;

    public enum GameState { Start, Playing, GameOver};
    public GameState gameState;


    //most of this code is from the tutorial
    private void Start()
    {
        timerMesh = timer.GetComponent<TMPro.TextMeshProUGUI>();
        gameState = GameState.Start;
        
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.Start:
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    gameTimer = 0;
                    gameState = GameState.Playing;
                    break;
                }
            case GameState.Playing:
                {
                    gameTimer += Time.deltaTime;

                    float time = gameTimer;
                    timerMesh.text = Snapping.Snap(time, 0.01f).ToString();
                    bool gameOver = true;
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] != null)
                        {
                            gameOver = false;
                        }
                        
                    }
                    if (gameOver)
                    {
                        gameState = GameState.GameOver;
                        scoreManager.AddScoreToHighScores(time);
                        scoreManager.SaveScoresToFile();
                    }

                    break;
                }

            case GameState.GameOver:
                {
                    Cursor.lockState = CursorLockMode.None;
                    break;
                }
        }
    }

}

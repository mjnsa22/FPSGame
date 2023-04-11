using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public float[] highScores = new float[10];
    string currentDirectory;
    public string scoreFileName = "Resources/highScores.txt";

    //all code from tutorial
    private void Start()
    {
        currentDirectory = Application.dataPath;
        Debug.Log("Our current directory is: " + currentDirectory);
        LoadScoresFromFile();
    }

    public void SaveScoresToFile()
    {
        StreamWriter fileWriter = new StreamWriter(currentDirectory + "\\"+scoreFileName);
        for (int i = 0; i<highScores.Length; i++)
        {
            fileWriter.WriteLine(highScores[i]);
        }
        fileWriter.Close();
        Debug.Log("High Scores written to " + scoreFileName);
    }

    public void AddScoreToHighScores(float newScore)
    {
        int desiredIndex = -1;
        for (int i = 0; i < highScores.Length; i++){
            if (highScores[i] > newScore || highScores[i] == 0)
            {
                desiredIndex = i;
                break;
            }
        }
        if (desiredIndex < 0)
        {
            Debug.Log("Score of " + newScore + " not high enough for highscore list ", this);
            return;
        }
        for (int i = highScores.Length-1; i>desiredIndex; i--)
        {
            highScores[i] = highScores[i - 1];

        }

        highScores[desiredIndex] = newScore;
        Debug.Log($"score  of {newScore} added into highscores at position {desiredIndex} , {this}");

    }

    public void LoadScoresFromFile()
    {
        bool fileExists = File.Exists(currentDirectory+"\\"+scoreFileName);
        if (fileExists == true)
        {
            Debug.Log("found high score file " + scoreFileName);

        }
        else
        {
            Debug.Log($"the file {scoreFileName} does not exist, no scores will be loaded, {this}");
            return;
        }

        highScores = new float[highScores.Length];
        StreamReader fileReader = new StreamReader(currentDirectory + "\\" + scoreFileName);
        int scoreCount = 0;

        while (fileReader.Peek() != 0 && scoreCount < highScores.Length)
        {
            string fileLine = fileReader.ReadLine();
            float readScore = -1;
            bool didParse = float.TryParse(fileLine, out readScore);
            if (didParse)
            {
                highScores[scoreCount] = readScore;
            }
            else
            {
                Debug.Log($"Invalid line in scores file at {scoreCount} , using default value, {this}");
                highScores[scoreCount] = 0;
            }
            scoreCount++;
        }
        fileReader.Close();
        Debug.Log("Highscores read from " + scoreFileName);
    }

}

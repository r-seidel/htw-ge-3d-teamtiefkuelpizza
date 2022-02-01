using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public bool scoring;

    private TextMeshPro scoreText;
    private TextMeshPro highText;
    private int highscore;
    public int score = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        highText = transform.GetChild(0).GetComponent<TextMeshPro>();
        highscore = PlayerPrefs.GetInt("Highscore");
        UpdateText();
    }

    private void SetHighscore(int newHigh)
    {
        PlayerPrefs.SetInt("Highscore", newHigh);
        highscore = newHigh;
    }

    public void UpdateText()
    {
        scoreText.text = $"SCORE\n{score}";
        highText.text = $"HIGH {highscore}";
    }


    // functions to manipulate score etc

    public void IncreaseScore(int plus = 1)
    {
        if (scoring)
        {
            score += plus;
        }

        UpdateText();
    }

    public void DecreaseScore(int minus = 1)
    {
        if (scoring)
        {
            score -= minus;

            if (score < 0)
            {
                score = 0;
            }
        }

        UpdateText();
    }

    public void CollectResults()
    {
        scoring = false;

        if(score > highscore)
        {
            SetHighscore(score);
            UpdateText();
        }
    }
}

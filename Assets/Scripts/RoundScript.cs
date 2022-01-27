using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundScript : MonoBehaviour
{
    public GameObject handMeshGo;
    public int maxLifes;

    private int lifes;
    private bool gameOver = false;

    private void Start()
    {
        lifes = maxLifes;
    }

    private void UpdateHand()
    {
        handMeshGo.GetComponent<LifeIndicatorScript>().SetHealthPercentage((float)lifes / maxLifes);
        Debug.Log($"Now at {lifes} life/s ({(float)lifes / maxLifes * 100}%)");
    }

    public void IncreaseLifes(int plus = 1)
    {
        //Debug.Log($"Gained {plus} life/s");
        lifes += plus;
        UpdateHand();
    }

    public void DecreaseLifes(int minus = 1)
    {
        //Debug.Log($"Lost {minus} life/s");

        lifes -= minus;
        UpdateHand();

        if (lifes <= 0)
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        if (!gameOver)
        {
            gameOver = true;
            GameObject.Find("Score").GetComponent<ScoreScript>().CollectResults();

            Debug.Log("GAME OVER");
            //GameObject hand = GameObject.Find("Hand rigged_animated");
            //Destroy(hand);
        }
    }
}
